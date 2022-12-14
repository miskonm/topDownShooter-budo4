using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Level
{
    [CreateAssetMenu(fileName = Tag, menuName = "StaticData/LevelSettingsContainer")]
    public class LevelSettingsContainer : ScriptableObject
    {
        private const string Tag = nameof(LevelSettingsContainer);

        [SerializeField] private LevelSettings[] _settings;

        private readonly Dictionary<string, LevelSettings> _settingsById = new Dictionary<string, LevelSettings>();

        private void OnEnable()
        {
            _settingsById.Clear();

            if (_settings == null)
                return;

            foreach (var setting in _settings)
            {
                if (_settingsById.ContainsKey(setting.SceneName))
                {
                    Debug.LogError($"There are 2 settings with id '{setting.SceneName}'");
                }
                else
                {
                    _settingsById.Add(setting.SceneName, setting);
                }
            }
        }

        public LevelSettings GetSettings(string id) =>
            _settingsById.ContainsKey(id) ? _settingsById[id] : null;

        public LevelSettings GetFirstLevelSettings() =>
            _settings[0];
    }
}