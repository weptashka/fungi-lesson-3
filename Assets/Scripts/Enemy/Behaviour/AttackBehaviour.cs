namespace Assets.Scripts.Enemy
{
    public class AttackBehaviour : EnemyBehaviour
    {
        private readonly PlayerTrigger _attackTrigger;
        private readonly EnemyController _enemyController;

        public AttackBehaviour(EnemyBehaviourController enemyBehaviourController, PlayerTrigger attackTrigger, EnemyController enemyController) : base(enemyBehaviourController)
        {
            _attackTrigger = attackTrigger;
            _enemyController = enemyController;
        }

        public override void Tick()
        {
            if (_attackTrigger.IsTriggered)
            {
                _enemyController.EnemyAttakHandler.Attack(_attackTrigger.TriggeredValue);
            }
            else
            {
                _enemyBehaviourController.SwitchBehaviour<ChaseBehaviour>();
            }
        }

        public override void Exit()
        {
        }
    }

}
