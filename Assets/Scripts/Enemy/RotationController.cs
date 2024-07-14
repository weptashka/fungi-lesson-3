using UnityEngine;

namespace Assets.Scripts
{
    public class RotationController
    { 
        private readonly Vector3 RIGHT_ROTATION_VECTOR = new Vector3(0, 0, 0);
        private readonly Vector3 LEFT_ROTATION_VECTOR = new Vector3(0, 180, 0);

        private readonly Quaternion _rightRotation;
        private readonly Quaternion _leftRotation;
        private readonly Transform _transform;

        public RotationController(Transform transform) 
        {
            _transform = transform;

            _rightRotation = Quaternion.Euler(RIGHT_ROTATION_VECTOR);
            _leftRotation = Quaternion.Euler(LEFT_ROTATION_VECTOR);
        }

        public void Rotate(Vector3 targetPoint)
        {
            var direction = (targetPoint - _transform.position).normalized;

            _transform.rotation = direction.x > 0 ? _rightRotation : _leftRotation;
        }
    }
}
