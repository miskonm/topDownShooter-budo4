using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyFollowAgro : MonoBehaviour
    {
        [SerializeField] private EnemyFollow _follow;
        [SerializeField] private EnemyBackToIdle _backToIdle;
        [SerializeField] private TriggerObserver _triggerObserver;

        private void Start()
        {
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        private void OnEntered(Collider2D col)
        {
            _backToIdle.Deactivate();
            _follow.Activate();
        }

        private void OnExited(Collider2D other)
        {
            _follow.Deactivate();
            _backToIdle.Activate();
        }
    }
}