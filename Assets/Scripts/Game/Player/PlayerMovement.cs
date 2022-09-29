using TDS.Game.InputService;
using UnityEngine;

namespace TDS.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private float _speed = 4f;
        
        private Transform _cachedTransform;
        private Rigidbody2D _rb;

        private IInputService _inputService;

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cachedTransform = transform;
        }

        private void Update()
        {
            if (_inputService == null)
                return;
            
            Move();
            Rotate();
        }

        private void Move()
        {
            var direction = _inputService.Axes;
            Vector3 moveDelta = direction * _speed;
            _rb.velocity = moveDelta;

            _playerAnimation.SetSpeed(direction.magnitude);
        }

        private void Rotate()
        {
            _cachedTransform.up = _inputService.LookDirection;
        }
    }
}