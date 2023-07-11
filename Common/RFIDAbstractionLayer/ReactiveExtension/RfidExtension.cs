using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using NodaTime;
using RFIDAbstractionLayer.Readers;

namespace RFIDAbstractionLayer.ReactiveExtension
{
    public static class RfidExtension
    {
        /// <summary>
        /// Subscribes all readers of the collection and returns an observable stream of tags.
        /// The observable stream must be disposed to unsubscribe the readers and free the resources. 
        /// </summary>
        /// <param name="rfidReaderCollection">The RFID reader collection to subscribe on. </param>
        /// <param name="scheduler">Observe on this scheduler. </param>
        /// <returns>An observable stream of EPC codes (tags). </returns>
        public static IObservable<string[]> SubscribeAsObservable(this RFIDReaderCollection rfidReaderCollection, IScheduler scheduler = null)
        {
            var observable = Observable.Create<string[]>(observer =>
            {
                var action = new Action<ReadingResult[]>(s => observer.OnNext(s.Select(x => x.Value).ToArray()));
                rfidReaderCollection.SubscribeAll(action);
                return rfidReaderCollection.UnsubscribeAll;
            });
            
            return scheduler != null ? observable.ObserveOn(scheduler) : observable;
        }
        
        public static IObservable<long> Delay(Duration delay, IScheduler scheduler)
        {
            var interval = Duration.FromMilliseconds(100);
            return Observable.Interval(interval.ToTimeSpan(), scheduler)
                .TakeUntil(Observable.Timer(delay.ToTimeSpan(), scheduler));
        }

        public static IObservable<Unit> DelayAndReport(Duration delay, Action<int> report, IScheduler scheduler)
        {
            var scaleFactorToPercent = Duration.FromMilliseconds(100).TotalMilliseconds * 100 / delay.TotalMilliseconds;
            // call report every 100ms until totalDelayInSeconds has elapsed
            var obs = Delay(delay, scheduler)
                .Select(x => x * scaleFactorToPercent)
                .ObserveOn(scheduler);

            obs.Subscribe(x => report((int)x));
            return obs.Select(_ => Unit.Default);
        }
    }
}
