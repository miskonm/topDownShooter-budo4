using System;

namespace TDS.Infrastructure.Persistant
{
    [Serializable]
    public class PersistantPlayerData
    {
        public bool IsSaved;
        public int CurrentHp;
    }
}