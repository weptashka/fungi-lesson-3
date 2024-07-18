using UnityEngine;

namespace Assets.Scripts
{
    public class BulletFactory : MonoBehaviour 
    {
        [SerializeField] public Bullet _bullet;

        public Bullet GetBullet(BulletType bulletType)
        { 
            return Instantiate(_bullet);
        } 
    }
}
    