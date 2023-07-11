using System;

namespace RFIDAbstractionLayer.Readers
{
    /// <summary>
    /// Interface to communicate with the abstraction layer for the RFID reader.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public interface IRFIDReader
    {
        /// <summary>
        /// Get device information like Model, Serial etc.
        /// </summary>
        /// <returns></returns>
        DeviceInformation GetDeviceInformation();

        /// <summary>
        /// Get the current power level on the RFID reader
        /// </summary>
        /// <returns></returns>
        PowerLevel GetPower();
        /// <summary>
        /// Set the power level on the RFID reader
        /// </summary>
        /// <param name="powerValue"></param>
        void SetPower(PowerLevel powerValue);

        /// <summary>
        /// Read the RFID tag from the RFID Reader
        /// </summary>
        /// <returns></returns>
        ReadingResult[] ReadTags();

        /// <summary>
        /// Connect is run right after instantiation.
        /// </summary>
        bool Connect();

        /// <summary>
        /// Is the instance connected to the physical reader?
        /// </summary>
        /// <returns></returns>
        bool IsConnected();

        /// <summary>
        /// Disconnects the underlying reader
        /// </summary>
        void Disconnect();

        void Subscribe(Action<ReadingResult[]> callback);

        void UnsubscribeAll();
    }
}
