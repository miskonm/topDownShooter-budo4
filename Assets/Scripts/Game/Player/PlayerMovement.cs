using UnityEngine;

namespace TDS.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private float _speed = 4f;
        private Transform _cachedTransform;
        private Camera _mainCamera;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cachedTransform = transform;
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var direction = new Vector2(horizontal, vertical);
            Vector3 moveDelta = direction * _speed;
            _rb.velocity = moveDelta;

            _playerAnimation.SetSpeed(direction.magnitude);
        }

        private void Rotate()
        {
            var mousePosition = Input.mousePosition;
            var worldPoint = _mainCamera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0f;

            var direction = worldPoint - _cachedTransform.position;
            _cachedTransform.up = direction;
        }
    }
}