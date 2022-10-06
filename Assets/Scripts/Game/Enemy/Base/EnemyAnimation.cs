using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int IsDead = Animator.StringToHash("IsDead");

        [SerializeField] private Animator _animator;

        public void PlayAttack() =>
            _animator.SetTrigger(IsAttack);

        public void SetSpeed(float speed) =>
            _animator.SetFloat(Speed, speed);

        public void PlayDeath() =>
            _animator.SetBool(IsDead, true);
    }
}