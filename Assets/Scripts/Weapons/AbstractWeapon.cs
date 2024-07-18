using UnityEngine;

namespace Assets.Scripts
{
    public abstract class AbstractWeapon : IWeapon
    {
        protected float _fireRate;
        private int _bulletCount;
        protected BulletType _bulletType;
        protected BulletFactory _bulletFactory;
        protected WeaponView _weaponView;

        protected AbstractWeapon(BulletFactory bulletFactory, WeaponView weaponView)
        {
            _bulletFactory = bulletFactory;
            _weaponView = weaponView;
        }

        public abstract void Fire();
    }
}
    