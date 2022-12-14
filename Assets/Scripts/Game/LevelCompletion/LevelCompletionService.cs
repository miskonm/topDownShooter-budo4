using TDS.Game.Level;
using TDS.Game.Mission;
using TDS.Infrastructure.StateMachine;

namespace TDS.Game.LevelCompletion
{
    public class LevelCompletionService : ILevelCompletionService
    {
        private readonly IMissionService _missionService;
        private readonly ILevelSettingsService _levelSettingsService;
        private readonly IGameStateMachine _stateMachine;

        public LevelCompletionService(IMissionService missionService, ILevelSettingsService levelSettingsService,
            IGameStateMachine stateMachine)
        {
            _missionService = missionService;
            _levelSettingsService = levelSettingsService;
            _stateMachine = stateMachine;
        }

        public void Init()
        {
            _missionService.OnCompleted += MissionCompleted;
        }

        public void Dispose()
        {
            _missionService.OnCompleted -= MissionCompleted;
        }

        private void MissionCompleted()
        {
            // TODO: Show completed ui
            // TODO: Stop game
            LevelSettings currentLevelSetting = _levelSettingsService.GetCurrentLevelSetting();

            if (currentLevelSetting.NextLevel == null)
            {
                // TODO: Show game over
                return;
            }

            _stateMachine.Enter<GameState, string>(currentLevelSetting.NextLevel.SceneName);
        }
    }
}