using UnityEngine;

namespace Assets.Scripts.Enemy
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

        public void Attack(PlayerController player)
        {
            if (Time.time - _lastAttackTime > _attackDelay)
            {
                _lastAttackTime = Time.time;

                Debug.Log("ENEMY ATTACK");
            }
        }
    }
}
