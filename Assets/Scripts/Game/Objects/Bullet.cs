using System.Collections;
using UnityEngine;

namespace TDS.Game.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifeTime = 3f;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = transform.up * _speed;

            StartCoroutine(LifeTimeTimer());
        }

        private IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);

            Destroy(gameObject);
        }
    }
}