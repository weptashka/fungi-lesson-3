using UnityEngine;

namespace Assets.Scripts
{
    public class Rigidbody2DMоvement
    {
        private const float MIN_DISTANCE_POW = 0.001f;

        private readonly Rigidbody2D _rb;
        private readonly float _speed;
        private readonly Vector2[] _movementPoints;

        private int index = 0;
        Vector3 currentTargetPoint;

        public Vector3 Direction => _rb.velocity.normalized;

        public Rigidbody2DMоvement(Rigidbody2D rb, float speed)
        {
            _rb = rb;
            _speed = speed;
        }
        
        public Rigidbody2DMоvement(Rigidbody2D rb, float speed, Vector2[] movementPoints)
        {
            _rb = rb;
            _speed = speed;
            _movementPoints = movementPoints;
        }

        public void MovementByPoints()
        {
            currentTargetPoint = _movementPoints[index];

            MoveByDirectionToPoint(currentTargetPoint);

            var distanceInPow = _rb.transform.position.DistancePow(currentTargetPoint);
            if (distanceInPow < MIN_DISTANCE_POW)
            {
                index += 1;

                if (index == _movementPoints.Length)
                {
                    index = 0;
                }
            }
        }

        public void MoveByDirectionToPoint(Vector3 targetPoint)
        {
            var direction = (targetPoint - _rb.transform.position).normalized;
            _rb.velocity = direction * _speed;
        }

        public void Stop()
        {
            _rb.velocity = Vector3.zero;
        }
    }
}
