using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Caretag_Class.Model;
using CheckboxStation.Services;
using ReactiveUI;

namespace CheckboxStation.Views
{
   
    internal class ViewHelpers
    {
        public enum CheckState
        {
            CheckedIn,
            CheckedOut,
            Mix
        }

        public static ListViewItem[] ToPresentation(List<IGrouping<string, Instrument_RFID>> groupedInstruments)
        {
            var list = groupedInstruments.Select(instrumentsWithCount =>
            {
                var instrument = instrumentsWithCount.First();

                var links = groupedInstruments.SelectMany(i => i)
                    .SelectMany(i => i.OperationInstruments).Select(oi => oi.ActiveLink).ToList();
                var checkState = links.All(l => l) ? CheckState.CheckedIn :
                    links.Any(l => l) ? CheckState.Mix : CheckState.CheckedOut;
                
                var i = new[]
                {
                    instrumentsWithCount.Count().ToString(),
                    instrument?.Description_ID ?? "Unknown",
                    $"{instrument?.InstrumentDescription?.Description_Name ?? "Unknown"} {instrument?.InstrumentDescription?.D ?? ""} {instrument?.InstrumentDescription?.E ?? ""}",
                    checkState == CheckState.CheckedIn ? "C.In" : checkState == CheckState.Mix ? "Mixed!" : "C.Out"
                };
                return new ListViewItem(i);
            }).ToArray();
            return list;
        }
        

    }
}
