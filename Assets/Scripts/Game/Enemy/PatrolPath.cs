using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class PatrolPath : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;

        public List<Transform> Points => _points;

        private int _currentIndex;
        
        public bool IsReached(Vector3 currentPosition, float distanceToPoint)
        {
            Vector3 pointPosition = CurrentPoint().position;
            float distance = Vector2.Distance(currentPosition, pointPosition);
            return distance <= distanceToPoint;
        }

        public void SetNextPoint()
        {
            _currentIndex++;

            if (_currentIndex >= _points.Count)
                _currentIndex = 0;
        }

        public Transform CurrentPoint() =>
            _points[_currentIndex];
    }
}