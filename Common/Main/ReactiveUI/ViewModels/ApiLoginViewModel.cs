using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag.Contracts.Core;
using Caretag_Class.EventReporting;
using Caretag_Class.Forms;
using Caretag_Class.Model;
using Caretag_Class.ReactiveUI.Services;
using DevExpress.Xpo.Logger;
using Main.Repositories;
using Main.Repositories.UnitOfWork;
using ReactiveUI;
using Surgical_Admin.Interactions;
using Westwind.Utilities;


namespace Main.ReactiveUI.ViewModels
{
    public class ApiLoginViewModel : ReactiveObject
    {
        private readonly IIdentityService _identityService;

        private string _username;
        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        private bool _showError;
        public bool ShowError
        {
            get => _showError;
            set => this.RaiseAndSetIfChanged(ref _showError, value);
        }

        private bool _showForm;
        public bool ShowForm
        {
            get => _showForm;
            set => this.RaiseAndSetIfChanged(ref _showForm, value);
        }

        private bool _userNameHasFocus;
        public bool UserNameHasFocus
        {
            get => _userNameHasFocus;
            set => this.RaiseAndSetIfChanged(ref _userNameHasFocus, value);
        }

        private int _enterPressed;
        public int EnterPressed
        {
            get => _enterPressed;
            set => this.RaiseAndSetIfChanged(ref _enterPressed, value);
        }
        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set => this.RaiseAndSetIfChanged(ref _isLoggedIn, value);
        }

        private int _eventsHandled = 0;

        public IScheduler Scheduler { get; set; }

        private volatile bool loadInProgress;

        public ApiLoginViewModel(IIdentityService identityService, IScheduler? scheduler = null)
        {
            _identityService = identityService;

            Scheduler = scheduler ?? RxApp.MainThreadScheduler;
            _showForm = true;
            Username = "";
            Password = "";

            // when Username or Password changes, set ShowError to false
            this.WhenAny(x => x.Username, x => x.Password, (x, y) => true)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(_ => ShowError = false);

            Login = ReactiveCommand.CreateFromObservable(() =>
                {
                    return Observable.StartAsync(async () =>
                    {
                        if (Username.Length < 3)
                        {
                            ShowError = true;
                        }


                        var loginResult = await _identityService.Login(Username, Password);

                        if (!loginResult)
                        {
                            IsLoggedIn = false;
                            ShowError = true;
                        }
                        else
                        {
                            ShowError = false;
                            IsLoggedIn = true;
                            ShowForm = false;
                        }

                    }, Scheduler);
                });

            Close = ReactiveCommand.CreateFromObservable(() =>
            {
                IsLoggedIn = false;
                ShowForm = false;
                return Observable.Return(Unit.Default);
            });
        }
        public ReactiveCommand<Unit, Unit> Login { get; }
        public ReactiveCommand<Unit, Unit> Close { get; }
    }
}
