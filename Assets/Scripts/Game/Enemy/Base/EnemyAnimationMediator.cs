using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimationMediator : MonoBehaviour
    {
        [SerializeField] private EnemyMeleeAttack _meleeAttack;

        public void PerformDamage()
        {
            _meleeAttack.PerformDamage();
        }
    }
}