using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Base;
using FluentValidation;

namespace Main.Util
{
    /// <summary>
    /// Validator used for validating DevExpress Grids. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RowValidator<T> : AbstractValidator<T> where T : class
    {
        /// <summary>
        /// Should be bound to the ValidateRow event in the view to enable support for validation.
        /// </summary>
        /// <param name="eventArgs"></param>
        public void RowValidating(EventPattern<object> eventArgs)
        {
            var rowEventArgs = eventArgs.EventArgs as ValidateRowEventArgs;
            var viewModel = rowEventArgs.Row as T;
            if (viewModel == null)
                return;
            var results = Validate(viewModel);
            rowEventArgs.Valid = results.IsValid;
            if (!results.IsValid)
            {
                var sb = new StringBuilder();
                foreach (var error in results.Errors)
                {
                    sb.AppendLine(error.ErrorMessage);
                }
                rowEventArgs.ErrorText = sb.ToString();
            }
        }

    }
}
