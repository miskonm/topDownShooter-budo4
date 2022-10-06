using TDS.Infrastructure;

namespace TDS.Game.Level
{
    public interface ILevelSettingsService : IService
    {
        void Bootstrap();
        void SetCurrentLevelSettings(string id);
        LevelSettings GetCurrentLevelSetting();
        LevelSettings GetFirstLevelSettings();
        LevelSettings GetLevelSettings(string id);
    }
}