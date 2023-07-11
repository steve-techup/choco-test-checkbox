using AdminStation.ViewModels.DataTypeViewModels;
using FluentValidation;
using Main.Util;

namespace AdminStation.ViewModels.Validation
{
    public class CostCenterValidator : RowValidator<CostCenterViewModel>
    {
        public CostCenterValidator()
        {
            RuleFor(x => x.Cost_Center_Name).NotEmpty().WithMessage("Cost Center cannot be empty");
            RuleFor(x => x.Cost_Center_Name).Length(0, 50).WithMessage("Cost Center cannot be longer than 50 characters");
            //   RuleFor(x => x.Cost_Center_Name).Must(BeUnique).WithMessage("Cost Center must be unique");
            RuleFor(x => x.Cost_Center_Code).NotEmpty().WithMessage("Cost Center Code cannot be empty");
            RuleFor(x => x.Cost_Center_Code).Length(0, 50).WithMessage("Cost Center Code cannot be longer than 50 characters");
            RuleFor(x => x.Cost_Center_Code).Matches("\\d+").WithMessage("Cost Center Code must be a number");
            RuleFor(x => x.Default_Always).NotNull().WithMessage("Default Always cannot be empty");
            RuleFor(x => x.Hidden_Center).NotNull().WithMessage("Hidden cannot be empty"); }

    }
}
