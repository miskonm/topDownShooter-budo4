using TDS.Infrastructure;

namespace TDS.Game.LevelCompletion
{
    public interface ILevelCompletionService : IService
    {
        void Init();
        void Dispose();
    }
}