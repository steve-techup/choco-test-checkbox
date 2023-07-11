using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactiveUI;

namespace AdminStation.ViewModels
{
    internal interface ExcelExportableViewModel
    {
        ReactiveCommand<Unit, Unit> ExportToExcelCommand { get; }
    }
}
