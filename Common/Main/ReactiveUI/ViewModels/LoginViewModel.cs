using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.EventReporting;
using Caretag_Class.Forms;
using Caretag_Class.Model;
using Caretag_Class.ReactiveUI.Services;
using DevExpress.Xpo.Logger;
using Main.Repositories;
using Main.Repositories.UnitOfWork;
using ReactiveUI;
using Surgical_Admin.Interactions;

namespace Main.ReactiveUI.ViewModels
{
    public class LoginViewModel : ReactiveObject
    {
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
        
        private TblPassword? _loggedInUser;
        public TblPassword? LoggedInUser
        {
            get => _loggedInUser;
            set => this.RaiseAndSetIfChanged(ref _loggedInUser, value);
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

        private int _eventsHandled = 0;

        public IScheduler Scheduler { get; set; }

        private volatile TblPassword? _cachedUser;
        private volatile bool loadInProgress;

        public LoginViewModel(LoginUnitOfWorkFactory unitOfWorkFactory, ReactiveCommandService reactiveCommandService, IScheduler? scheduler = null)
        {
            Scheduler = scheduler ?? RxApp.MainThreadScheduler;
            _showForm = true;
            Username = "";
            Password = "";

            var loader = this.WhenAny(x => x.Username,
                    x => x.UserNameHasFocus, (x
                        ,y) => false)
                .Merge(this.WhenAny(x => x.EnterPressed, x => true))
                .ObserveOn(RxApp.TaskpoolScheduler)                      
                .Select(enterPressed =>
                {
                    loadInProgress = true;
                    using var unitOfWork = unitOfWorkFactory.Create();
                    if ((!UserNameHasFocus || enterPressed) && Username.Length > 2 )
                    {
                        _cachedUser = unitOfWork?.UserRepository.Get(x => x.UserName == Username).FirstOrDefault();
                    }
                    loadInProgress = false;
                    return true;
                });
            loader.Subscribe();

            // when Username or Password changes, set ShowError to false
            this.WhenAny(x => x.Username, x => x.Password, (x, y) => true)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(_ => ShowError = false);
            
            Login = ReactiveCommand.CreateFromObservable(() =>
            {
                return Observable.StartAsync(() =>
                {
                    if (_cachedUser == null && Username.Length <3)
                    {
                        ShowError = true;
                        return Task.CompletedTask;
                    }

                    loader.ObserveOn(Scheduler).Subscribe(x =>
                    {
                        TblPassword user = _cachedUser;

                        if (user == null)
                        {
                            ShowError = true;
                            return;
                        }

                        var encryptedEnteredPassword = PasswordEncryptionUtil.EncryptWithGuid(Password, user.UserGuid ?? Guid.Empty);
                        if (user.PassCode != encryptedEnteredPassword)
                        {
                            ShowError = true;
                            return;
                        }

                        ShowError = false;
                        LoggedInUser = user;
                        ShowForm = false;
                    });
                    return Task.CompletedTask;
                }, Scheduler);
            });
            
            reactiveCommandService.HandleExceptions(Login,
                "An error occurred while logging in. ",
                "Error in Login command", "Main-01", ReportLevel.Error);

            Close = ReactiveCommand.CreateFromObservable(() =>
            {
                LoggedInUser = null;
                ShowForm = false;
                return Observable.Return(Unit.Default);
            });
            reactiveCommandService.HandleExceptions(Login,
                "An error occurred while closing login form. ",
                "Error in Close command", "Main-02", ReportLevel.Error);

        }

        public ReactiveCommand<Unit, Unit> Login { get; }
        public ReactiveCommand<Unit, Unit> Close { get; }
    }
}
