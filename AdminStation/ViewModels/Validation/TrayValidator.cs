using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminStation.ViewModels.DataTypeViewModels;
using FluentValidation;
using LanguageExt;
using Main.Util;

namespace AdminStation.ViewModels.Validation
{
    public class TrayValidator : RowValidator<TrayViewModel>
    {
        public TrayValidator()
        {
            RuleFor(x => x.Deleted_Tray).NotNull().WithMessage("Deleted flag must be set");
            RuleFor(x => x.Hide_Tray).NotNull().WithMessage("Hidden must set");
            RuleFor(x => x.Tray_Lock).NotNull().WithMessage("Locked flag must be set");
            RuleFor(x => x.Tray_Name).NotEmpty().WithMessage("Tray name must be set");

        }
    }
}
