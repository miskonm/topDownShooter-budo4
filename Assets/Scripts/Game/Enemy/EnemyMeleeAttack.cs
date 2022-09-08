using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMeleeAttack : EnemyAttack
    {
        [SerializeField] private int _damage = 2;
        [SerializeField] private float _attackDelay;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;

        private float _delayTimer;

        protected override void OnUpdate()
        {
            TickTimer();
        }

        protected override void OnActiveUpdate()
        {
            base.OnActiveUpdate();

            Attack();
        }

        private void TickTimer()
        {
            _delayTimer -= Time.deltaTime;
        }

        private void Attack()
        {
            if (CanAttack())
                AttackInternal();
        }

        private bool CanAttack()
        {
            return _delayTimer <= 0;
        }

        private void AttackInternal()
        {
            _delayTimer = _attackDelay;
            var col = Physics2D.OverlapCircle(_attackPoint.position, _radius, _layerMask);
            if (col == null)
                return;

            var playerHp = col.GetComponentInParent<PlayerHp>();
            if (playerHp != null)
                playerHp.ApplyDamage(_damage);
        }
    }
}