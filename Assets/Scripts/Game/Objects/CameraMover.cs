using UnityEngine;

namespace TDS.Game.Objects
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private Transform _follow;

        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void LateUpdate()
        {
            var followPosition = _follow.position;
            followPosition.z = _cachedTransform.position.z;
            _cachedTransform.position = followPosition;
        }
    }
}