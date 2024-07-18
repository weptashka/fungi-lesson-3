using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponView : MonoBehaviour 
    {
        [SerializeField] private Transform _firePosition;

        public Transform FirePosition => _firePosition;

        public Vector3 FireDirection => transform.right;
    }
}
    