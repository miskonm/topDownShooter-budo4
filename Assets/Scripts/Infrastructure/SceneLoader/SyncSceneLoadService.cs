using System;
using UnityEngine.SceneManagement;

namespace TDS.Infrastructure.SceneLoader
{
    public class SyncSceneLoadService : ISceneLoadService
    {
        public void Load(string sceneName, Action completeCallback)
        {
            // TODO: Fix one frame
            SceneManager.LoadScene(sceneName);
            completeCallback?.Invoke();
        }
    }
}