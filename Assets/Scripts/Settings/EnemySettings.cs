using System;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Settings/EnemySettings", fileName = "EnemySettings", order = 0)]
    public class EnemySettings : ScriptableObject
    {
        [SerializeField] private EnemyPreset[] _enemyPresets;

        public EnemyPreset[] EnemyPresets => _enemyPresets;
    }

    [Serializable]
    public class EnemyPreset
    {
        [Header("Triggers")]
        [SerializeField] private float _attackRadius;
        [SerializeField] private float _chaseRadius;
        [Header("Movement")]
        [SerializeField] private float _speed;
        [SerializeField] private Vector3[] _movementPoints;
        [Header("Attack")]
        [SerializeField] private float _attackDelay;
        [SerializeField] private int _damage;

        public float AttackRadius => _attackRadius;
        public float ChaseRadius => _chaseRadius;
        public float Speed => _speed;
        public Vector3[] MovementPoints => _movementPoints;
        public float AttackDelay => _attackDelay;
        public int Damage => _damage;
    }
}

