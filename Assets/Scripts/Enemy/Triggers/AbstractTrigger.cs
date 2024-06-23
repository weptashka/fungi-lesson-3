using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class AbstractTrigger<T> : MonoBehaviour
    {
        public bool IsTriggered => TriggeredValue != null;

        public T TriggeredValue
        {
            get;
            private set;
        }

        private void Awake()
        {
            //доп проверка
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out T value))
            {
                TriggeredValue = value;
            }  
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out T value))
            {
                TriggeredValue = default(T);
            }  
        }
    }
}
