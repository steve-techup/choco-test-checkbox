using System.Reactive.Concurrency;
using System.Resources;
using Caretag_Class.ReactiveUI.Services;
using Main.Repositories.UnitOfWork;
using Microsoft.Extensions.Logging;
using Surgical_Admin.Interactions;

namespace Main.ReactiveUI.Interactions
{
    public class CommonInteractionsFactory
    {
        private readonly ILogger<CommonInteractions> _logger;
        private readonly ResourceManager _resourceManager;
        private readonly LoginUnitOfWorkFactory _loginUnitOfWorkFactory;
        private readonly ReactiveCommandService _reactiveCommandService;

        public CommonInteractionsFactory(ILogger<CommonInteractions> logger, ResourceManager resourceManager,
            LoginUnitOfWorkFactory loginUnitOfWorkFactory)
        {
            _logger = logger;
            _resourceManager = resourceManager;
            _loginUnitOfWorkFactory = loginUnitOfWorkFactory;
        }

        public CommonInteractionsFactory()
        {

        }
        
        public virtual CommonInteractions Create(IScheduler? scheduler)
        {
            return new CommonInteractions(_logger, _resourceManager, _loginUnitOfWorkFactory, scheduler);
        }
    }
}
