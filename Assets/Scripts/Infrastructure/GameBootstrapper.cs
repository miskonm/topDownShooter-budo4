using TDS.Infrastructure.StateMachine;
using UnityEngine;

namespace TDS.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log($"Start In GameBootstrapper");

            GameStateMachine gameStateMachine = new GameStateMachine();
            Services.Container.Register<IGameStateMachine>(gameStateMachine);
            
            gameStateMachine.Enter<BootstrapState>();
        }
    }
}