using UnityEngine;

namespace Assets.Scripts.Enemy
{

    public class ChaseBehaviour : EnemyBehaviour
    {
        private readonly EnemyBehaviourController _enemyBehaviourController;
        private readonly PlayerTrigger _chaseTrigger;
        private readonly PlayerTrigger _attackTrigger;
        private readonly EnemyController _enemyController;

        public ChaseBehaviour(EnemyBehaviourController enemyBehaviourController, PlayerTrigger chaseTrigger, PlayerTrigger attackTrigger, EnemyController enemyController) : base(enemyBehaviourController)
        {
            _enemyBehaviourController = enemyBehaviourController;
            _chaseTrigger = chaseTrigger;
            _attackTrigger = attackTrigger;
            _enemyController = enemyController;
        }

        public override void Tick()
        {
            if (_attackTrigger.IsTriggered)
            {
                _enemyBehaviourController.SwitchBehaviour<AttackBehaviour>();
                Debug.Log("ATTACK MODE");
            }
            else if (_chaseTrigger.IsTriggered)
            {
                Debug.Log("CHASE MODE");
                _enemyController.Rigidbody2DMovement.MoveByDirectionToPoint(_chaseTrigger.TriggeredValue.transform.position);
            }
            else
            {
                _enemyBehaviourController.SwitchBehaviour<PatrollingBehaviour>();
                Debug.Log("PATROLLING MODE");
            }
        }

        public override void Exit()
        {
            _enemyController.Rigidbody2DMovement.Stop();
        }

#if UNITY_EDITOR
        public override void DrawGizmo()
        {
            base.DrawGizmo();
            Gizmos.color = Color.gray;
            Gizmos.DrawLine(_enemyController.transform.position, _chaseTrigger.TriggeredValue.transform.position);
        }
#endif
    }
}
