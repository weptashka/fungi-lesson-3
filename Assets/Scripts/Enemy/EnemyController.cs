﻿using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class EnemyController : MonoBehaviour
    {
        [Header("Triggers")]
        [SerializeField] private PlayerTrigger _chaseTrigger;
        [SerializeField] private PlayerTrigger _attackTrigger;
        [SerializeField] private float _attackRadius;
        [SerializeField] private float _chaseRadius;
        [Space]
        [SerializeField] private EnemyAnimationController _enemyAnimationController;
        [Header("Movement")]
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;
        [SerializeField] private Path _path;
        [Header("Attack")]
        [SerializeField] private float _attackDelay;
        [SerializeField] private int _damage;
        [Header("Chase")]
        [SerializeField] private LayerMask _layerMask;
        [Space]
        [SerializeField] private float _viewAngle;
        [Space]
        [SerializeField] private LifeHandler _lifeHandler;

        private EnemyBehaviourController _enemyBehaviourController;
        private Rigidbody2DMоvement _rigidbody2DMovement;
        private EnemyAttakHandler _enemyAttakHandler;
        private RotationController _rotationController;

        public LifeHandler LifeHandler => _lifeHandler;
        public Rigidbody2DMоvement Rigidbody2DMovement => _rigidbody2DMovement;
        public EnemyAttakHandler EnemyAttakHandler => _enemyAttakHandler;
        public RotationController RotationController => _rotationController;

        private void Awake()
        {
            _path.ToLocal();
            _rigidbody2DMovement = new Rigidbody2DMоvement(_rb, _speed, _path.LocalMovementPoints);
            _enemyAttakHandler = new EnemyAttakHandler(_attackDelay, _damage);
            _rotationController = new RotationController(transform);

            CreateEnemyBehaviourController();
        }

        private void Update()
        {
            _enemyBehaviourController.Tick();
        }

        private void CreateEnemyBehaviourController()
        {

            _enemyBehaviourController = new EnemyBehaviourController(_chaseTrigger, _attackTrigger, this, _enemyAnimationController);
            _enemyBehaviourController.SwitchBehaviour<PatrollingBehaviour>();
        }

        public bool CanStartChase(Vector3 playerPosition)
        {
            var direction = (playerPosition - _rb.transform.position).normalized;

            var position = transform.position;

            var angle = Vector3.Angle(transform.right, direction);

            if (angle > _viewAngle)
            {
                return false;
            }

            var raycastHit2D = Physics2D.Raycast(transform.position, direction, _chaseRadius, _layerMask);

            Debug.DrawRay(position, direction);

            if (raycastHit2D)
            {
                return raycastHit2D.transform.gameObject.TryGetComponent(out PlayerController playerController);
            }

            return false;
        }

#if UNITY_EDITOR
        public void OnValidate()
        {
            _chaseTrigger.GetComponent<CircleCollider2D>().radius = _chaseRadius;
            _attackTrigger.GetComponent<CircleCollider2D>().radius = _attackRadius;
        }

        private void OnDrawGizmos()
        {
            if (_enemyBehaviourController != null)
            {
                _enemyBehaviourController.OnDrawGizmo();
            }

            Gizmos.color = Color.red;

            var transform1 = transform;
            Gizmos.DrawRay(transform1.position, transform1.right * _chaseRadius);

            Gizmos.color = Color.yellow;

            var right = Quaternion.AngleAxis(_viewAngle, Vector3.forward) * transform1.right;
            var left = Quaternion.AngleAxis(-_viewAngle, Vector3.forward) * transform1.right;
            Gizmos.DrawRay(transform1.position, right);
            Gizmos.DrawRay(transform1.position, left);
        }
#endif
    }
}


