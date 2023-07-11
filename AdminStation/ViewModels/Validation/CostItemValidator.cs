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
    public class CostItemValidator : RowValidator<CostItemViewModel>
    {
        public CostItemValidator()
        {
            //Only need to validate the Cost Item Default field, since the rest cannot be edited

            RuleFor(x => x.DefaultCost).NotNull().WithMessage("Default cannot be empty");
        }
            
    }
}
