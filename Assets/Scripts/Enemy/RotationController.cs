using UnityEngine;
using static UnityEngine.GridBrushBase;

namespace Assets.Scripts.Enemy
{
    public class RotationController
    { 
        private readonly Transform _transform;
        private readonly Vector3 _rightRotationVector = new Vector3(0, 0, 0);
        private readonly Vector3 _leftRotationVector = new Vector3(0, 180, 0);
        private readonly Quaternion _rightRotation;
        private readonly Quaternion _leftRotation;



        public RotationController(Transform transform) 
        {
            _transform = transform;

            _rightRotation = Quaternion.Euler(_rightRotationVector);
            _leftRotation = Quaternion.Euler(_leftRotationVector);
        }

        public void Rotate(Vector3 targetPoint)
        {
            var direction = (targetPoint - _transform.position).normalized;

            _transform.rotation = direction.x > 0 ? _rightRotation : _leftRotation;
        }
    }
}
