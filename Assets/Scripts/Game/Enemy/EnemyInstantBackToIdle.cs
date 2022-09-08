using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyInstantBackToIdle : EnemyBackToIdle
    {
        [SerializeField] private EnemyIdle _idle;

        private void OnEnable()
        {
            _idle.Activate();
        }
    }
}