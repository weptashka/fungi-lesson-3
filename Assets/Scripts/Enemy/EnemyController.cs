using UnityEngine;
using System.Collections;
using Assets.Scripts.Settings;

namespace Assets.Scripts.Enemy
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
        [SerializeField] private Vector3[] _movementPoints;
        [Header("Attack")]
        [SerializeField] private float _attackDelay;
        [SerializeField] private int _damage;

        private EnemyBehaviourController _enemyBehaviourController;
        private LifeHandler _lifeHandler;
        private Rigidbody2DMоvement _rigidbody2DMovement;
        private EnemyAttakHandler _enemyAttakHandler;

        public LifeHandler LifeHandler => _lifeHandler;
        public Rigidbody2DMоvement Rigidbody2DMovement => _rigidbody2DMovement;
        public EnemyAttakHandler EnemyAttakHandler => _enemyAttakHandler;

        private void Awake()
        {
            CreateEnemyBehaviourController();
            _lifeHandler = new LifeHandler(10);
            _rigidbody2DMovement = new Rigidbody2DMоvement(_rb, _speed, _movementPoints);
            _enemyAttakHandler = new EnemyAttakHandler(_attackDelay, _damage);
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


#if UNITY_EDITOR
        public void OnValidate()
        {
            _chaseTrigger.GetComponent<CircleCollider2D>().radius = _chaseRadius;
            _attackTrigger.GetComponent<CircleCollider2D>().radius = _attackRadius;
        }

        void OnDrawGizmos()
        {
            // Draws four lines making a square
            Gizmos.color = Color.blue;
            for (int i = 0; i < _movementPoints.Length - 1; i++)
            {
                Gizmos.DrawLine(_movementPoints[i], _movementPoints[i + 1]);

                if (i  == _movementPoints.Length - 2)
                {
                    Gizmos.DrawLine(_movementPoints[i + 1], _movementPoints[0]);
                }
            }
        }
#endif

    }
}


