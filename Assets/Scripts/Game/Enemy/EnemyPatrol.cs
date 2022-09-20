using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyPatrol : EnemyIdle
    {
        [SerializeField] private PatrolPath _path;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private float _distanceToPoint = 1f;

        public override void Activate()
        {
            base.Activate();

            SetCurrentPointAsTarget();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            SetTarget(null);
        }

        protected override void OnActiveUpdate()
        {
            base.OnActiveUpdate();

            CheckDistance();
        }

        private void CheckDistance()
        {
            if (_path.IsReached(transform.position, _distanceToPoint))
            {
                _path.SetNextPoint();
                SetCurrentPointAsTarget();
            }
        }

        private void SetCurrentPointAsTarget() =>
            SetTarget(_path.CurrentPoint());

        private void SetTarget(Transform target) =>
            _enemyMovement.SetTarget(target);
    }
}