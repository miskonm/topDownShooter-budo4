using TDS.Game.InputService;
using TDS.Game.Npc;
using TDS.Game.Player;
using TDS.Infrastructure.LoadingScreen;
using TDS.Infrastructure.SceneLoader;
using UnityEngine;

namespace TDS.Infrastructure.StateMachine
{
    public class GameState : BaseExitableState, IPayloadState<string>
    {
        private ISceneLoadService _sceneLoadService;
        private ILoadingScreenService _loadingScreenService;
        private INpcService _npcService;

        public GameState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public void Enter(string sceneName)
        {
            Services.Container.Get(out _sceneLoadService);
            Services.Container.Get(out _loadingScreenService);

            _loadingScreenService.ShowScreen();
            _sceneLoadService.Load(sceneName, OnSceneLoaded);
        }

        public override void Exit()
        {
            Dispose();
            UnRegisterLocalServices();

            _loadingScreenService = null;
            _sceneLoadService = null;
        }

        private void Dispose()
        {
            _npcService.Dispose();
        }

        private void UnRegisterLocalServices()
        {
            Services.Container.UnRegister<IInputService>();
            Services.Container.UnRegisterAndNullRef(ref _npcService);
        }

        private void OnSceneLoaded()
        {
            // TODO: Init all local services
            RegisterLocalServices();

            Initialize();
            _loadingScreenService.HideScreen();
        }

        private void Initialize()
        {
            _npcService.Init();
        }

        private void RegisterLocalServices()
        {
            PlayerMovement playerMovement = Object.FindObjectOfType<PlayerMovement>();
            RegisterInputService(playerMovement);
            InitPlayerMovement(playerMovement);
            _npcService = Services.Container.Register<INpcService>(new NpcService());
        }

        private void RegisterInputService(PlayerMovement playerMovement)
        {
            Services.Container.Register<IInputService>(
                new StandaloneInputService(Camera.main, playerMovement.transform));
        }

        private void InitPlayerMovement(PlayerMovement playerMovement)
        {
            playerMovement.Construct(Services.Container.Get<IInputService>());
        }
    }
}