using System;
using UnityEngine;


namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour, IDamageble
    {
        private class AnimatorKeys
        {
            public static int IsWalk = Animator.StringToHash("IsWalk");
            public static int Death = Animator.StringToHash("Death");
        }

        private class CinemachineKeys
        {
            public static int IsMapView = Animator.StringToHash("IsMapView");
        }

        [Header("Animator")]
        [SerializeField] private Animator[] _animators;
        [Header("Movement Control")]
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;
        [Header("Cinemachine")]
        [SerializeField] private Animator _cinemachineAnimator;
        [Space]
        [SerializeField] private LifeHandler _lifeHandler;
        [SerializeField] private AbstractDamageEffector[] _abstractDamageEffector;
        [Header("Weapon")]
        [SerializeField] private WeaponView _pistolView;
        [SerializeField] private BulletFactory _bulletFactory;

        [SerializeField] private Transform _weaponTransform;
        private Camera _mainCamera;

        private IWeapon _weapon;

        private string _horizontalAxis = "Horizontal";
        private string _verticallAxis = "Vertical";

        private RotationController _rotationController;

        public bool IsDied => _lifeHandler.IsDied;

        private void Awake()
        {
            _rotationController = new RotationController(transform);
            _weapon = new Pistol(_bulletFactory, _pistolView);
        }

        private void Start()
        {
            _lifeHandler.Changed += LifeHandlerOnChanged;
        }

        private void OnDestroy()
        {
            _lifeHandler.Changed -=  LifeHandlerOnChanged;
        }

        private void LifeHandlerOnChanged()
        {
            foreach (var effect in _abstractDamageEffector)
            {
                effect.MakeEffect();
            }
        }

        private void FixedUpdate()
        {
            var axis = GetAxis();

            if (axis != Vector3.zero)
            {
                Move(axis);
                _rotationController.Rotate(transform.position + axis);
                Animate(axis);
            }

            SwapView(Input.GetKey(KeyCode.Tab));


            RotateWeapon();
            TryFire();
        }

        private void RotateWeapon()
        {
            var mousePos = Input.mousePosition;
            mousePos.z = _mainCamera.nearClipPlane;
            var worldPosition = _mainCamera.ScreenToWorldPoint(mousePos);

            var position = new Vector3(worldPosition.x, worldPosition.y);
            Quaternion.LookRotation(transform.position, position);

            _weaponTransform.LookAt(position, -transform.forward);
        }

        private void TryFire()
        {
            if (Input.GetMouseButton(0))
            {
                _weapon.Fire();
            }
        }

        private void SwapView(bool isMapView)
        {
            _cinemachineAnimator.SetBool(CinemachineKeys.IsMapView, isMapView);
        }

        private Vector3 GetAxis()
        {
            var horizontalAxis = Input.GetAxisRaw(_horizontalAxis);
            var verticalAxis = Input.GetAxisRaw(_verticallAxis);

            return new Vector3(horizontalAxis, verticalAxis);
        }

        private void Move(Vector3 inputVector)
        {
            _rb.MovePosition(transform.position + inputVector * (Time.deltaTime * _speed));
        }


        private void Animate(Vector3 axis)
        {
            foreach (var animator in _animators)
            {
                animator.SetBool(AnimatorKeys.IsWalk, !axis.Equals(Vector3.zero));

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetTrigger(AnimatorKeys.Death);
                }
            }
        }

        private void Test()
        {
            Debug.Log("DEATH EVENT");
        }

        public void TakeDamage(int damage)
        {
            _lifeHandler.TakeDamage(damage);
        }
    }
}