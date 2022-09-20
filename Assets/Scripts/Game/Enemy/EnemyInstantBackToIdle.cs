using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyInstantBackToIdle : EnemyBackToIdle
    {
        [SerializeField] private EnemyIdle _idle;

        public override void Activate()
        {
            base.Activate();
            
            Deactivate();
            _idle.Activate();
        }
    }
}