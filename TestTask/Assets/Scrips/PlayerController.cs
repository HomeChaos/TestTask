using UnityEngine;

namespace Scrips
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _minimumDistance = 0.02f;
        [SerializeField, Range(0f, 1f)] private float _directionThreshold = 0.5f;
        [SerializeField] private float _defaultGravity = 9.8f;
        
        private Vector2 _startPosition = Vector2.zero;
        private Vector2 _endPosition;

        public void SwipeCheck(bool start)
        {
            if (!start)
                ShowDebag();
        }

        public void SetPosition(Vector2 position)
        {
            if (_startPosition == Vector2.zero)
                _startPosition = position;
            else
                _endPosition = position;
        }

        private void ShowDebag()
        {
            if (Vector3.Distance(_startPosition, _endPosition) >= _minimumDistance)
            {
                Vector3 direction = _endPosition - _startPosition;
                Vector2 directio2D = new Vector2(direction.x, direction.y).normalized;
                SwipeDirection(directio2D);
            }
            _startPosition = Vector2.zero;
        }

        private void SwipeDirection(Vector2 direction)
        {
            if (Vector2.Dot(Vector2.up, direction) > _directionThreshold)
            {
                Physics2D.gravity = new Vector3(0, _defaultGravity, 0);
            }

            if (Vector2.Dot(Vector2.down, direction) > _directionThreshold)
            {
                Physics2D.gravity = new Vector3(0, -_defaultGravity, 0);
            }

            if (Vector2.Dot(Vector2.left, direction) > _directionThreshold)
            {
                Physics2D.gravity = new Vector3(-_defaultGravity, 0f, 0);
            }

            if (Vector2.Dot(Vector2.right, direction) > _directionThreshold)
            {
                Physics2D.gravity = new Vector3(_defaultGravity, 0, 0);
            }
                
        }
    }
}