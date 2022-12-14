using TDS.Game.Level;
using TDS.Infrastructure.Persistant;

namespace TDS.Infrastructure.StateMachine
{
    public class BootstrapState : BaseState
    {
        private readonly ILevelSettingsService _levelSettingsService;
        private readonly IPersistantService _persistantService;

        public BootstrapState(IGameStateMachine gameStateMachine, ILevelSettingsService levelSettingsService,
            IPersistantService persistantService) : base(gameStateMachine)
        {
            _levelSettingsService = levelSettingsService;
            _persistantService = persistantService;
        }

        public override void Enter()
        {
            _levelSettingsService.Bootstrap();
            _persistantService.Bootstrap();
            
            StateMachine.Enter<MenuState>();
        }

        public override void Exit()
        {
        }
    }
}