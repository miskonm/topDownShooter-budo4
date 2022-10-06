using TDS.Game.Npc;

namespace TDS.Game.Mission
{
    public class KillAllEnemiesMission : Mission<KillAllEnemiesMissionCondition>
    {
        private readonly INpcService _npcService;

        public KillAllEnemiesMission(INpcService npcService)
        {
            _npcService = npcService;
        }

        public override void Init() =>
            _npcService.OnAllDead += AllEnemiesDead;

        public override void Dispose() =>
            _npcService.OnAllDead -= AllEnemiesDead;

        private void AllEnemiesDead() =>
            Complete();
    }
}