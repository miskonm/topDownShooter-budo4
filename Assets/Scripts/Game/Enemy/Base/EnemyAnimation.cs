using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");
        private static readonly int Speed = Animator.StringToHash("Speed");

        [SerializeField] private Animator _animator;

        public void PlayAttack() =>
            _animator.SetTrigger(IsAttack);

        public void SetSpeed(float speed) =>
            _animator.SetFloat(Speed, speed);
    }
}