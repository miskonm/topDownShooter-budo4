using UnityEngine;

namespace TDS.Infrastructure.LoadingScreen
{
    public class LoadingScreenService : ILoadingScreenService
    {
        private const string LoadingScreenPath = "LoadingScreen";

        private GameObject _loadingScreen;

        public void ShowScreen()
        {
            if (_loadingScreen == null)
            {
                LoadScreen();
            }

            _loadingScreen.SetActive(true);
        }

        public void HideScreen() =>
            _loadingScreen.SetActive(false);

        private void LoadScreen()
        {
            GameObject prefab = Resources.Load<GameObject>(LoadingScreenPath);
            _loadingScreen = Object.Instantiate(prefab);
            Object.DontDestroyOnLoad(_loadingScreen);
        }
    }
}