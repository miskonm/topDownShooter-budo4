using System;
using TDS.Game.InputService;
using TDS.Game.Level;
using TDS.Game.LevelCompletion;
using TDS.Game.Mission;
using TDS.Game.Npc;
using TDS.Infrastructure.LoadingScreen;
using TDS.Infrastructure.Persistant;
using TDS.Infrastructure.SceneLoader;
using TDS.Infrastructure.StartLevel;
using TDS.Infrastructure.StateMachine;
using TDS.Infrastructure.Utility;

namespace TDS.Infrastructure
{
    public static class ServicesRegister
    {
        public static void RegisterFor<TState>() where TState : class, IExitableState
        {
            Type type = typeof(TState);

            if (type == typeof(BootstrapState))
            {
                RegisterBootstrap();
            }
            else if (type == typeof(MenuState))
            {
                RegisterMenu();
            }
            else if (type == typeof(GameState))
            {
                RegisterGame();
            }
        }

        public static void UnregisterFor(Type type)
        {
            if (type == typeof(GameState))
            {
                UnregisterGame();
            }
            else if (type == typeof(MenuState))
            {
                UnregisterMenu();
            }
        }

        private static void RegisterBootstrap()
        {
            Services.Container.RegisterMono<ICoroutineRunner>(typeof(CoroutineRunner));
            Services.Container.Register<ISceneLoadService>(
                new AsyncSceneLoadService(Services.Container.Get<ICoroutineRunner>()));

            Services.Container.Register<ILoadingScreenService>(new LoadingScreenService());
            Services.Container.Register<ILevelSettingsService>(new LevelSettingsService());
            Services.Container.Register<IPersistantService>(new PersistantService());
        }

        private static void RegisterMenu()
        {
            ILevelSettingsService levelSettingsService = Services.Container.Get<ILevelSettingsService>();
            IGameStateMachine gameStateMachine = Services.Container.Get<IGameStateMachine>();
            IPersistantService persistantService = Services.Container.Get<IPersistantService>();

            Services.Container.Register<IStartLevelService>(new StartLevelService(levelSettingsService,
                gameStateMachine, persistantService));
        }

        private static void UnregisterMenu()
        {
            Services.Container.UnRegister<IStartLevelService>();
        }

        private static void RegisterGame()
        {
            Services.Container.Register<IInputService>(new StandaloneInputService());
            Services.Container.Register<INpcService>(new NpcService());

            IMissionService missionService = Services.Container.RegisterMono<IMissionService>(typeof(MissionService));

            ILevelSettingsService levelSettingsService = Services.Container.Get<ILevelSettingsService>();
            IGameStateMachine gameStateMachine = Services.Container.Get<IGameStateMachine>();

            Services.Container.Register<ILevelCompletionService>(
                new LevelCompletionService(missionService, levelSettingsService, gameStateMachine));
        }

        private static void UnregisterGame()
        {
            Services.Container.UnRegister<IInputService>();
            Services.Container.UnRegister<INpcService>();
            Services.Container.UnRegister<IMissionService>();
            Services.Container.UnRegister<ILevelCompletionService>();
        }
    }
}