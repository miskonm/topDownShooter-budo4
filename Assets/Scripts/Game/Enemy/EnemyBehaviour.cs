using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        private bool _isActive;

        private void Update()
        {
            OnUpdate();
            
            if (_isActive)
                OnActiveUpdate();
        }

        public virtual void Activate() { }
        public virtual void Deactivate() { }

        
        protected virtual void OnUpdate() { }
        protected virtual void OnActiveUpdate() { }
    }
}