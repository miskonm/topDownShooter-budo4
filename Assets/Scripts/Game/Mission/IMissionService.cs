using System;
using TDS.Infrastructure;

namespace TDS.Game.Mission
{
    public interface IMissionService : IService
    {
        event Action OnCompleted;
        
        void Init();
        void Dispose();
    }
}