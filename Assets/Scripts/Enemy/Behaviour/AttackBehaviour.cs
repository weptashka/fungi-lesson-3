namespace Assets.Scripts.Enemy
{
    public class AttackBehaviour : EnemyBehaviour
    {
        private readonly PlayerTrigger _attackTrigger;
        private readonly Enemy _enemy;

        public AttackBehaviour(EnemyBehaviourController enemyBehaviourController, PlayerTrigger attackTrigger, Enemy enemy) : base(enemyBehaviourController)
        {
            _attackTrigger = attackTrigger;
            _enemy = enemy;
        }

        public override void Tick()
        {
            if (_attackTrigger.IsTriggered)
            {
                _enemy.Attack(_attackTrigger.TriggeredValue);
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
