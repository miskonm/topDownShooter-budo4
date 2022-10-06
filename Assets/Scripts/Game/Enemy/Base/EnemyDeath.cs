using System;
using TDS.Utility;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHp _enemyHp;
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private Collider2D[] _colliders;

        private bool _isDead;

        public event Action<EnemyDeath> OnHappened;

        private void Start()
        {
            _enemyHp.OnChanged += HpChanged;
        }

        private void HpChanged(int hp)
        {
            if (_isDead || hp > 0)
                return;

            _isDead = true;
            _animation.PlayDeath();
            _enemyMovement.SetTarget(null);
            _colliders.ForEach(x => x.enabled = false);
            OnHappened?.Invoke(this);
        }
    }
}