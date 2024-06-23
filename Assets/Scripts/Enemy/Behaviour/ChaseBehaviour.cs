using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class ChaseBehaviour : EnemyBehaviour
    {
        private readonly EnemyBehaviourController _enemyBehaviourController;
        private readonly PlayerTrigger _chaseTrigger;
        private readonly PlayerTrigger _attackTrigger;
        private readonly Enemy _enemy;

        public ChaseBehaviour(EnemyBehaviourController enemyBehaviourController, PlayerTrigger chaseTrigger, PlayerTrigger attackTrigger, Enemy enemy) : base(enemyBehaviourController)
        {
            _enemyBehaviourController = enemyBehaviourController;
            _chaseTrigger = chaseTrigger;
            _attackTrigger = attackTrigger;
            _enemy = enemy;
        }

        public override void Tick()
        {
            if (_attackTrigger.IsTriggered)
            {
                _enemyBehaviourController.SwitchBehaviour<AttackBehaviour>();
                Debug.Log("_attackTrigger.IsTriggered");
            }
            else if (_chaseTrigger.IsTriggered)
            {
                Debug.Log("_chaseTrigger.IsTriggered");
                _enemy.Move(_chaseTrigger.TriggeredValue.transform.position);
            }
            else 
            {
                _enemyBehaviourController.SwitchBehaviour<InactionBehaviour>();
                Debug.Log("patrolling");
            }
        }

        public override void Exit()
        {
            _enemy.Stop();
        }
    }

}
