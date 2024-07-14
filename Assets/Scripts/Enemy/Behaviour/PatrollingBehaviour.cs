using UnityEngine;

namespace Assets.Scripts
{
    public class PatrollingBehaviour : EnemyBehaviour
    {
        private readonly PlayerTrigger _chaseTrigger;
        private readonly EnemyBehaviourController _enemyBehaviourController;
        private readonly EnemyController _enemyController;

        public PatrollingBehaviour(EnemyBehaviourController enemyBehaviourController, PlayerTrigger chaseTrigger, EnemyController enemyController) : base(enemyBehaviourController)
        {
            _chaseTrigger = chaseTrigger;
            _enemyBehaviourController = enemyBehaviourController;
            _enemyController = enemyController;
        }

        public override void Tick()
        {
            if (_chaseTrigger.IsTriggered && _enemyController.CanStartChase(_chaseTrigger.TriggeredValue.transform.position))
            {
                _enemyBehaviourController.SwitchBehaviour<ChaseBehaviour>();
            }

            _enemyController.Rigidbody2DMovement.MovementByPoints();
        }

        public override void Exit()
        {
            _enemyController.Rigidbody2DMovement.Stop();
        }
    }

}
