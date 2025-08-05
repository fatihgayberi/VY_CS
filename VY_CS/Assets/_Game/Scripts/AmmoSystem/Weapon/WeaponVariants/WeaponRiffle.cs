using UnityEngine;
using VY_CS.AmmoSystem.Bullet;
using VY_CS.AmmoSystem.Magazine;

namespace VY_CS.AmmoSystem.Weapon
{
    public class WeaponRiffle : WeaponBase
    {
        [SerializeField] private BulletMagazine magazine;

        public override void Shoot()
        {
            if (magazine == null) return;

            BulletBase bullet = magazine.GetBullet();

            if (bullet == null) return;

            bullet.transform.position = transform.position;
            bullet.gameObject.SetActive(true);

            bullet.LifeStart();
        }
    }
}