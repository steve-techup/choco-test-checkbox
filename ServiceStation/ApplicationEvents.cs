using System;
using Microsoft.Extensions.DependencyInjection;

namespace Service_Station.My
{
    // The following events are available for MyApplication:
    // Startup: Raised when the application starts, before the startup form is created.
    // Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    // UnhandledException: Raised if the application encounters an unhandled exception.
    // StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    // NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    internal partial class MyApplication
    {
        private void MyApplication_NetworkAvailabilityChanged(object sender, Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs e)
        {
            try
            {
                if (e.IsNetworkAvailable)
                {
                    Program.Kernel.GetRequiredService<Network_Down>().Close();
                }
                else
                {
                    Program.Kernel.GetRequiredService<Network_Down>().ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}