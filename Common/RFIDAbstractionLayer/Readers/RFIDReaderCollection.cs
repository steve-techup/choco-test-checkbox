using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RFIDAbstractionLayer.Exceptions;
using Serilog;
using Westwind.Utilities;

namespace RFIDAbstractionLayer.Readers
{
    /// <summary>
    /// Wraps all readers in the system and handles automatic retries. There should only be one instance in the system (handled by the IoC container). 
    /// </summary>
    public class RFIDReaderCollection : IDisposable
    {
        private readonly RFIDReaderFactory _rfidReaderFactory;
        private readonly ILogger _logger;
        private readonly RfIdConfig _config;
        public virtual List<IRFIDReader> Readers { get; private set; }
        public int Subscribers { get; private set; }

        public RFIDReaderCollection()
        {
            // Unit test
        }

        /// <summary>
        /// Instantiates a new 
        /// </summary>
        /// <param name="simulated"></param>
        public RFIDReaderCollection(RFIDReaderFactory rfidReaderFactory, ILogger logger,  RfIdConfig config)
        {
            _rfidReaderFactory = rfidReaderFactory;
            _logger = logger;
            _config = config;
        }

        public virtual void ConnectAll()
        {
            Readers = _rfidReaderFactory.ConnectAll(_config);
        }
        public virtual void ConnectAll(RfIdConfig config)
        {
            _logger.Information("ConnectAll executed");
            Readers = _rfidReaderFactory.ConnectAll(config);
        }

        public virtual void DisconnectAll()
        {
            Readers.ForEach(r => LanguageUtils.IgnoreErrors(r.Disconnect));
            Readers.Clear();
        }

        public virtual int Count
        {
            get
            {
                return Readers.Count;
            }
        }

        /// <summary>
        /// Reads tags from all connected readers. If any readers lost their connection or there was an error reading from one or more readers,
        /// a new auto-connect and auto-discovery attempt will be made. If this fails and no readers can be found an exception will be thrown. 
        /// </summary>
        /// <exception cref="RFIDReaderConnectionException">Thrown on failure to re-connect to any readers. </exception>
        /// <returns></returns>
        public virtual ReadingResult[] ReadTags()
        {
            
            try
            {
                if (AllConnected())
                    return Readers.SelectMany(r => r.ReadTags()).ToArray();
            }
            catch
            {
                // ignored
            }

            _logger.Debug("Lost connection to one or more readers. Re-connecting all. ");
            for (int i = 0; i < 5; i++)
            {
                ConnectAll();
                if (Readers.Count == 0)
                    Thread.Sleep(300 * i^2);
            }

            if (Readers.Count == 0)
                throw new RFIDReaderConnectionException(
                    "No readers connected to the system. Try to disconnect and re-connect all readers and restart the application. ");

            return Readers.SelectMany(r => r.ReadTags()).ToArray();
        }


        private volatile bool _readCallbackInProgress;

        private readonly Mutex _subscribeMutex = new Mutex();
        public virtual void SubscribeAll(Action<ReadingResult[]> callback)
        {
            SubscribeAllWithDebounce(callback, 500);
        }

        public virtual void SubscribeAllWithDebounce(Action<ReadingResult[]> callback, int debounceMs)
        {
            Readers.ForEach(reader => reader.Subscribe((r) =>
            {
                if (_readCallbackInProgress)
                    return;
                try
                {
                    _subscribeMutex.WaitOne();
                    _readCallbackInProgress = true;
                }
                finally
                {
                    _subscribeMutex.ReleaseMutex();
                }

                Task.Run(() =>
                {
                    callback(r);
                    if (debounceMs > 0)
                        Thread.Sleep(debounceMs);
                    _readCallbackInProgress = false;
                });
            }));
            Subscribers++;
        }


        public virtual void UnsubscribeAll()
        {
            _logger.Information("UnsubscribeAll executed");
            Readers.ForEach(reader => reader.UnsubscribeAll());
            Subscribers = 0;
        }

        public virtual bool AllConnected()
        {
            return Readers.TrueForAll(r => r.IsConnected());
        }


        public virtual List<IRFIDWriter> GetRFIDWriters()
        {
            List<IRFIDWriter> writers = new List<IRFIDWriter>();

            foreach (var reader in Readers)
            {
                if (reader.IsConnected())
                {
                    if (reader is IRFIDWriter)
                    {
                        writers.Add(reader as IRFIDWriter);
                    }
                }
            }

            return writers;
        }

        public void Dispose()
        {
            _subscribeMutex?.Dispose();
            Readers.ForEach(r =>
            {
                try
                {
                    r.UnsubscribeAll();
                }
                catch
                {
                    // ignored
                }

                if(r.IsConnected())
                    r.Disconnect();
            });
        }
    }
}
