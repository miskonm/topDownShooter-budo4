using TDS.Infrastructure.SceneLoader;
using UnityEngine;

namespace TDS.Infrastructure.StateMachine
{
    public class BootstrapState : BaseState
    {
        public BootstrapState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log($"In BootstrapState");

            RegisterAllGlobalServices();
            ISceneLoadService sceneLoadService = Services.Container.Get<ISceneLoadService>();
            sceneLoadService.Load("MenuScene", OnSceneLoaded);
        }

        public override void Exit()
        {
        }

        private void OnSceneLoaded()
        {
            StateMachine.Enter<MenuState>();
        }

        private void RegisterAllGlobalServices()
        {
            Services.Container.Register<ISceneLoadService>(new SyncSceneLoadService());
        }
    }
}