using AdminStation.ViewModels.DataTypeViewModels;
using Main.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class;
using FluentValidation;

namespace AdminStation.ViewModels.Validation
{
    public class UserValidator : RowValidator<UserViewModel>
    {
        private readonly CaretagModelFactory _caretagModelFactory;

        public UserValidator(CaretagModelFactory caretagModelFactory)
        {
            _caretagModelFactory = caretagModelFactory;
            RuleFor(model => model.Username).NotEmpty().WithMessage("Username must be set");
            RuleFor(model => model.Username).MinimumLength(3).WithMessage("Username must be at least 3 characters");
            RuleFor(model => model.FirstName).NotEmpty().WithMessage("First name must be set");
            RuleFor(model => model.FamilyName).NotEmpty().WithMessage("Family name must be set");
            RuleFor(model => model.Username).Must(BeUnique).WithMessage("Username must be unique");
            RuleFor(model => model.HasPassword).Equal(true).WithMessage("Password must be set");
        }

        private bool BeUnique(string arg)
        {
            using var caretagModel = _caretagModelFactory.Create();
            return caretagModel.TblPassword.Count(u => u.UserName == arg) <= 1;
        }
    }
}
