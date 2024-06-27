using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Rigidbody2DMоvement
    {
        private readonly Rigidbody2D _rb;
        private readonly float _speed;
        private readonly Vector3[] _movementPoints;

        private int index = 0;
        Vector3 currentTargetPoint;

        public Rigidbody2DMоvement(Rigidbody2D rb, float speed)
        {
            _rb = rb;
            _speed = speed;
        }
        
        public Rigidbody2DMоvement(Rigidbody2D rb, float speed, Vector3[] movementPoints)
        {
            _rb = rb;
            _speed = speed;
            _movementPoints = movementPoints;
        }

        //public void MovementByPoints()
        //{
        //    currentTargetPoint = _movementPoints[index];

        //    MoveByDirectionToPoint(currentTargetPoint);

        //    if (_rb.transform.position.x - currentTargetPoint.x < 0.01f && _rb.transform.position.y - currentTargetPoint.y < 0.01f)
        //    {
        //        Debug.Log($"{_rb.transform.position.x} {currentTargetPoint.x}  {_rb.transform.position.y} {currentTargetPoint.y}");

        //        index += 1;

        //        if (index == _movementPoints.Length)
        //        {
        //            index = 0;
        //        }
        //    }


        //    Debug.Log($"{_rb.transform.position.x - currentTargetPoint.x < 0.01f && _rb.transform.position.y - currentTargetPoint.y < 0.01f} {index}");

        //}

        public void MovementByPoints()
        {
            currentTargetPoint = _movementPoints[index];

            MoveByDirectionToPoint(currentTargetPoint);

            if (_rb.transform.position.x - currentTargetPoint.x < 0.01f && _rb.transform.position.y - currentTargetPoint.y < 0.01f)
            {
                index = index == 1 ? 0 : 1;
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
