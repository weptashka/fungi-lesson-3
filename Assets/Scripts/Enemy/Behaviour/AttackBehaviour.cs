using UnityEngine;

namespace Assets.Scripts
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
                _enemyController.RotationController.Rotate(_attackTrigger.TriggeredValue.transform.position);
            }
            else
            {
                _enemyBehaviourController.SwitchBehaviour<ChaseBehaviour>();
            }
        }

        public override void Exit()
        {
        }

#if UNITY_EDITOR
        public override void DrawGizmo()
        {
            base.DrawGizmo();
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_enemyController.transform.position, _attackTrigger.TriggeredValue.transform.position);
        }
#endif
    }

}
