using TDS.Infrastructure;
using TDS.Infrastructure.StartLevel;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.Menu.UI
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private IStartLevelService _startLevelService;

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void Start()
        {
            _startLevelService = Services.Container.Get<IStartLevelService>();
        }

        private void OnPlayButtonClicked()
        {
            _startLevelService.StartGame();
        }
    }
}