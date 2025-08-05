using UnityEngine;
using VY_CS.AmmoSystem.Muzzle;
using VY_CS.AmmoSystem.Bullet;
using VY_CS.AmmoSystem.Magazine;
using System.Collections.Generic;

namespace VY_CS.AmmoSystem.Weapon
{
    public class WeaponRiffle : WeaponBase
    {
        [SerializeField] private MuzzleBase muzzleBase;
        [SerializeField] private BulletMagazine magazine;

        public override void Shoot()
        {
            if (magazine == null) return;

            HashSet<BulletBase> bullets = muzzleBase.GetBullets(magazine);

            foreach (BulletBase bullet in bullets)
            {
                bullet.gameObject.SetActive(true);
                bullet.LifeStart();
            }
        }
    }
}