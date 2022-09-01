using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 4;

        private Rigidbody2D _rb;
        [SerializeField] private Transform _target;
        private Transform _cachedTransform;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cachedTransform = transform;
        }

        private void OnDisable()
        {
            SetVelocity(Vector2.zero);
        }

        private void FixedUpdate()
        {
            if (!IsTargetValid())
                return;

            MoveToTarget();
            RotateToTarget();
        }

        public void SetTarget(Transform target)
        {
            _target = target;

            if (_target == null)
                SetVelocity(Vector2.zero);
        }

        private bool IsTargetValid() =>
            _target != null;

        private void MoveToTarget()
        {
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            SetVelocity(direction * _speed);
        }

        private void RotateToTarget()
        {
            Vector3 direction = _target.position - _cachedTransform.position;
            _cachedTransform.up = direction;
        }

        private void SetVelocity(Vector2 velocity) =>
            _rb.velocity = velocity;
    }
}