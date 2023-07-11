using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Caretag_Class.Model;
using Caretag_Class.ReactiveUI;
using CheckboxStation.Services;
using CheckboxStation.ViewModels;
using CheckboxStation.Views;
using Microsoft.Reactive.Testing;
using Moq;
using ReactiveUI.Testing;
using Surgical_Admin.Interactions;
using Xunit;

namespace Tests.CheckboxStation
{
    public class CheckInViewModelTest
    {
        private readonly IFixture _fixture;

        public CheckInViewModelTest()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());

            _fixture.Behaviors.Remove(_fixture.Behaviors.OfType<ThrowingRecursionBehavior>().First());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var mock = new Mock<CheckStateService>();
            mock.Setup(c => c.GetOperations(OperationState.ACTIVE)).Returns(_fixture.CreateMany<Operation>().ToList());

            _fixture.Register(() => mock);
            _fixture.Register(() => mock.Object);
        }
        
        [Fact]
        public void CheckInViewModel_OK_SelectedOperationNull()
        {
            var interactionsMock = new Mock<CommonInteractions>();
            interactionsMock.Object.Confirm.RegisterHandler(interaction =>
                interaction.SetOutput( CaretagMessageBoxResult.Ok ));

            _fixture.Register(() => interactionsMock.Object);

            var sut = _fixture.Create<CheckInViewModel>();
            sut.SelectedOperation = null;
            sut.ShowForm = true;
            
            new TestScheduler().With(s =>
            {
                sut.Ok.Execute().Subscribe(_ =>
                {
                    Assert.True(sut.ShowForm);
                    _fixture.Create<Mock<CheckStateService>>().Verify(service => service.CheckInstrumentsIn(It.IsAny<List<Instrument_RFID>>(), It.IsAny<Operation>()), Times.Never);
                });

                s.Start();
            });
        }

        [Fact]
        public void CheckInViewModel_OK_With_SelectedOperation()
        {
            var interactionsMock = new Mock<CommonInteractions>();
            interactionsMock.Object.Confirm.RegisterHandler(interaction =>
                interaction.SetOutput(CaretagMessageBoxResult.Ok));

            _fixture.Register(() => interactionsMock.Object);

            var sut = _fixture.Create<CheckInViewModel>();
            var checkInServiceMock = _fixture.Create<Mock<CheckStateService>>();
            sut.SelectedOperation = checkInServiceMock.Object.GetOperations(OperationState.ACTIVE).First();
            sut.ShowForm = true;

            new TestScheduler().With(s =>
            {
                sut.Ok.Execute().Subscribe(_ =>
                {

                    Assert.False(sut.ShowForm);
                    _fixture.Create<Mock<CheckStateService>>().Verify(service => service.CheckInstrumentsIn(It.IsAny<List<Instrument_RFID>>(), It.IsAny<Operation>()), Times.Once);
                });

                s.Start();
            });
        }

        [Fact]
        public void CheckInViewModel_WithNoActiveOperations()
        {
            var interactionsMock = new Mock<CommonInteractions>();
            interactionsMock.Object.Confirm.RegisterHandler(interaction =>
                interaction.SetOutput(CaretagMessageBoxResult.Ok));

            _fixture.Register(() => interactionsMock.Object);
            
            var sut = _fixture.Create<CheckInViewModel>();
            sut.Operations = Observable.Return(new List<Operation>());
            sut.ShowForm = true;
            sut.SelectedOperation = null;

            new TestScheduler().With(s =>
            {
                var observable = Observable.Empty(s, true);
                
                observable.Subscribe(_ =>
                {
                    interactionsMock.Verify(interactions => interactions.Confirm.Handle(It.IsAny<CaretagMessageBoxArguments>()), Times.Once);
                    _fixture.Create<Mock<CheckStateService>>().Verify(service => service.CheckInstrumentsIn(It.IsAny<List<Instrument_RFID>>(), It.IsAny<Operation>()), Times.Never);
                });
                s.Start(() => observable);
            });
        }


        [Fact]
        public void CheckInViewModel_Cancel()
        {
            var interactionsMock = new Mock<CommonInteractions>();
            interactionsMock.Object.Confirm.RegisterHandler(interaction =>
                interaction.SetOutput(CaretagMessageBoxResult.Ok));

            _fixture.Register(() => interactionsMock.Object);
            
            var sut= _fixture.Create<CheckInViewModel>();
            sut.ShowForm = true;

            new TestScheduler().With(s =>
            {
                sut.Cancel.Execute().Subscribe(_ =>
                {
                    Assert.False(sut.ShowForm); 
                    _fixture.Create<Mock<CheckStateService>>().Verify(service => service.CheckInstrumentsIn(It.IsAny<List<Instrument_RFID>>(), It.IsAny<Operation>()), Times.Never);
                });

                s.Start();
            });
        }
    }
}
