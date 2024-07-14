using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    //our FSM
    public partial class EnemyBehaviourController
    {
        private readonly Dictionary<Type, EnemyBehaviour> _enemyBehaviours;

        private EnemyBehaviour _currentBehaviour;

        public EnemyBehaviour CurrentBehaviour => _currentBehaviour;
        
        public EnemyBehaviourController(PlayerTrigger chaseTrigger, PlayerTrigger attackTrigger, EnemyController enemyController, EnemyAnimationController enemyAnimationController)
        {
            _enemyBehaviours = new Dictionary<Type, EnemyBehaviour>()
            {
                //{ typeof(InactionBehaviour), new InactionBehaviour(this, chaseTrigger)},
                { typeof(PatrollingBehaviour), new PatrollingBehaviour(this, chaseTrigger, enemyController)},
                { typeof(ChaseBehaviour), new ChaseBehaviour(this, chaseTrigger, attackTrigger, enemyController)},
                { typeof(AttackBehaviour), new AttackBehaviour(this, attackTrigger, enemyController)},
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

        public void OnDrawGizmo() 
        {
            _currentBehaviour?.DrawGizmo();
        }
    }
}
