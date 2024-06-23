using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Enemy
{
    //our FSM
    public partial class EnemyBehaviourController
    {
        private readonly Dictionary<Type, EnemyBehaviour> _enemyBehaviours;

        private EnemyBehaviour _currentBehaviour;

        public EnemyBehaviour CurrentBehaviour => _currentBehaviour;
        
        public EnemyBehaviourController(PlayerTrigger chaseTrigger, PlayerTrigger attackTrigger, Enemy enemy, EnemyAnimationController enemyAnimationController)
        {
            _enemyBehaviours = new Dictionary<Type, EnemyBehaviour>()
            {
                { typeof(InactionBehaviour), new InactionBehaviour(this, chaseTrigger)},
                { typeof(ChaseBehaviour), new ChaseBehaviour(this, chaseTrigger, attackTrigger, enemy)},
                { typeof(AttackBehaviour), new AttackBehaviour(this, attackTrigger, enemy)},
            };
        }

        public void SwitchBehaviour<T>()
        {
            _currentBehaviour?.Exit();  
            _currentBehaviour = _enemyBehaviours[typeof(T)];
            _currentBehaviour.Enter();
        }

        public void Tick()
        {
            _currentBehaviour.Tick();
            Debug.Log(_currentBehaviour.GetType());
        }
    }
}
