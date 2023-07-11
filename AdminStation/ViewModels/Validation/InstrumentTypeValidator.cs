using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminStation.ViewModels.DataTypeViewModels;
using AdminStation.ViewModels.ReactiveUI;
using FluentValidation;
using Main.Util;

namespace AdminStation.ViewModels.Validation
{
    public class InstrumentTypeValidator : RowValidator<InstrumentTypeViewModel>
    {
        public InstrumentTypeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.RfidUntaggable).NotNull().WithMessage("RFID Untaggable cannot be empty");
            RuleFor(x => x.Vendor_ID).NotEmpty().WithMessage("Vendor ID cannot be empty");
        }
    }
}
