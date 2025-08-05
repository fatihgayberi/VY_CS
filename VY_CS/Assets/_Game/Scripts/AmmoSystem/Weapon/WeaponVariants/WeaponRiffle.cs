using VY_CS.AmmoSystem.Bullet;
using System.Collections.Generic;

namespace VY_CS.AmmoSystem.Weapon
{
    public class WeaponRiffle : WeaponBase
    {
        public WeaponRiffle(WeaponData weaponData) : base(weaponData) { }

        public override void Shoot()
        {
            if (_magazine == null) return;

            HashSet<BulletBase> bullets = _muzzleBase.PrepareBullets(_magazine);

            foreach (BulletBase bullet in bullets)
            {
                bullet.gameObject.SetActive(true);
                bullet.LifeStart();
            }
        }
    }
}