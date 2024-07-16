using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class LifeHandler : MonoBehaviour
    {
        public event Action Died;
        public event Action Changed;

        [SerializeField] private int _hp;
            
        public int Hp => _hp;

        public bool IsDied => _hp <= 0;

        public LifeHandler(int hp)
        {
            _hp = hp;
        }

        public void TakeDamage(int hp)
        {
            _hp -= hp;

            Changed?.Invoke();

            if (IsDied)
            {
                Died?.Invoke();
            }
        }
    }
}
