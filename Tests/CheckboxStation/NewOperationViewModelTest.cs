using System;
using CheckboxStation.ViewModels;
using Microsoft.Reactive.Testing;
using ReactiveUI.Testing;
using Xunit;

namespace Tests.CheckboxStation
{
    public class NewOperationViewModelTest
    {
        private readonly NewOperationViewModel _newOperationViewModel;

        public NewOperationViewModelTest()
        {
            _newOperationViewModel = new NewOperationViewModel();
        }

        [Fact]
        public void OkPressed()
        {
            new TestScheduler().With(s =>
            {
                _newOperationViewModel.Ok.Execute().Subscribe(_ =>
                {
                    Assert.True(_newOperationViewModel.CreateSuccess);
                });
                
                s.Start();
            });
        }

        [Fact]
        public void CancelPressed()
        {
            new TestScheduler().With(s =>
            {
                _newOperationViewModel.Cancel.Execute().Subscribe(_ =>
                {
                    Assert.False(_newOperationViewModel.CreateSuccess);
                });

                s.Start();
            });
        }
    }
}