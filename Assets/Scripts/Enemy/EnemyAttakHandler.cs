using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyAttakHandler
    {
        private readonly float _attackDelay = 5;
        private float _lastAttackTime;

        private readonly int _damage;

        public EnemyAttakHandler(float attackDelay, int damage)
        {
            _attackDelay = attackDelay;
            _damage = damage;
        }

        public void Attack(PlayerController playerController)
        {
            if (Time.time - _lastAttackTime > _attackDelay)
            {
                playerController.TakeDamage(_damage);

                Debug.Log("ATTACK");

                _lastAttackTime = Time.time;
            }
        }
    }
}
