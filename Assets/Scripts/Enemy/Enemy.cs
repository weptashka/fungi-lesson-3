using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private PlayerTrigger _chaseTrigger;
        [SerializeField] private PlayerTrigger _attackTrigger;
        [Space]
        [SerializeField] private EnemyAnimationController _enemyAnimationController;
        [Space]
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;
        [Space]
        [SerializeField] private float _attackDelay = 5;

        private float _lastAttackTime;

        private EnemyBehaviourController _enemyBehaviourController;

        private void Start()
        {
            _enemyBehaviourController = new EnemyBehaviourController(_chaseTrigger, _attackTrigger, this, _enemyAnimationController);
            _enemyBehaviourController.SwitchBehaviour<InactionBehaviour>();
        }

        private void Update()
        {
            _enemyBehaviourController.Tick();
        }
            
        public void Move(Vector3 targetPosition)
        {
            Debug.Log("ENEMY MOVE");

            var direction = (targetPosition - transform.position).normalized;
            _rb.velocity = direction * _speed;
            //_rb.AddForce(direction * (_speed * Time.deltaTime));
        }

        public void Attack(PlayerController player)
        {
            if(Time.time - _lastAttackTime > _attackDelay)
            {
                Debug.Log("ENEMY ATTACK");

                _lastAttackTime = Time.time;
            }
        }

        public void Stop()
        {
            Debug.Log("ENEMY STOP");
            _rb.velocity = Vector3.zero;
        }

    }
}
