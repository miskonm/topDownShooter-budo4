using UnityEngine;

namespace TDS.Game.Objects
{
    public class Explosive : MonoBehaviour
    {
        [SerializeField] private int _damage;

        private void Explode()
        {
            var colliders = Physics2D.OverlapCircleAll(Vector3.zero, 10);

            foreach (var col in colliders)
            {
                var health = col.GetComponentInParent<IHealth>();
                if (health != null)
                    health.ApplyDamage(_damage);
            }
        }
    }
}