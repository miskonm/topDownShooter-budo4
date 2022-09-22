using TDS.Infrastructure;
using TDS.Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.Menu.UI
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private IGameStateMachine _stateMachine;

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void Start()
        {
            _stateMachine = Services.Container.Get<IGameStateMachine>();
        }

        private void OnPlayButtonClicked()
        {
            _stateMachine.Enter<GameState>();
        }
    }
}