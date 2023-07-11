using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Model;
using FluentValidation;
using Main.Model.DevexpressModels;
using Main.Util;

namespace AdminStation.ViewModels.Validation
{
    public class InstrumentDescriptionValidator : RowValidator<InstrumentDescriptionXPOModel>
    {
        public InstrumentDescriptionValidator()
        {
            RuleFor(x => x.Description_Name).NotEmpty().WithMessage("Instrument name cannot be empty");
            RuleFor(x => x.Description_Name).Length(0, 50).WithMessage("Instrument name cannot be longer than 50 characters.");
            RuleFor(x => x.Vendor_ID).NotEmpty().WithMessage("Instrument vendor must be set. ");
        }
    }
}
