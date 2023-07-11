using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminStation.ViewModels.DataTypeViewModels;
using FluentValidation;
using Main.Util;

namespace AdminStation.ViewModels.Validation
{
    public class CostTypeValidator : RowValidator<CostTypeViewModel>
    {
        public CostTypeValidator()
        {
            RuleFor(x => x.Cost_Price).GreaterThan(0).NotEmpty().NotNull().WithMessage("Cost Price cannot be empty or negative");
            RuleFor(x => x.Cost_Type).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
