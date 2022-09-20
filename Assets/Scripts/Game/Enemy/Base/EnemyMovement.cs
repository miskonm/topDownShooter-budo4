using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyAnimation _animation;

        public abstract void SetTarget(Transform target);

        protected void SetAnimationSpeed(float speed) =>
            _animation.SetSpeed(speed);
    }
}