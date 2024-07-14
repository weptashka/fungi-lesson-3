namespace Assets.Scripts
{
    public class InactionBehaviour : EnemyBehaviour
    {
        protected readonly PlayerTrigger _chaseTrigger;

        public InactionBehaviour(EnemyBehaviourController enemyBehaviourController, PlayerTrigger chaseTrigger) : base(enemyBehaviourController)
        {
            _chaseTrigger = chaseTrigger;
        }

        public override void Tick()
        {
            if (_chaseTrigger.IsTriggered)
            {
                _enemyBehaviourController.SwitchBehaviour<ChaseBehaviour>();
            }
        }

        public override void Exit()
        {
        }
    }
}
   