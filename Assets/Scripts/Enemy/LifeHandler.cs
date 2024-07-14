using System;

namespace Assets.Scripts
{
    public class LifeHandler
    {
        public static event Action Died;

        private int _hp;
            
        public int Hp => _hp;

        public LifeHandler(int hp)
        {
            _hp = hp;
        }

        private void TakeDamage(int hp)
        {
            _hp -= hp;

            Died?.Invoke();
        }
    }
}
