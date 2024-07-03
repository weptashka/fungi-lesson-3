using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public abstract class EnemyBehaviour
    {
        protected EnemyBehaviourController _enemyBehaviourController;

        protected EnemyBehaviour(EnemyBehaviourController enemyBehaviourController) 
        {
            _enemyBehaviourController = enemyBehaviourController;
        }

        public virtual void Enter()
        {
           // Debug.Log(GetType());
        }

        //аналог Update в MonoBehaviour
        public abstract void Tick();

        public virtual void Exit() { }

        public virtual void DrawGizmo() { }
    }
}
