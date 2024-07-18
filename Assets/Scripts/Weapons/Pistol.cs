using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class Pistol : AbstractWeapon
    {
        private float _nextFireTime;

        public Pistol(BulletFactory bulletFactory, WeaponView weaponView) : base(bulletFactory, weaponView)
        {
        }

        public override void Fire() 
        {
            if (Time.time < _nextFireTime)
            {
                return;
            }

            _nextFireTime = Time.time + _fireRate;

            var bullet = _bulletFactory.GetBullet(_bulletType);

            bullet.transform.position = _weaponView.FirePosition.position;

            bullet.StartMove(_weaponView.FireDirection);
        }
    }
}
    