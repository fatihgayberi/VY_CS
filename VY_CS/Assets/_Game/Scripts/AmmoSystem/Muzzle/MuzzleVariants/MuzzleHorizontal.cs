using UnityEngine;
using VY_CS.AmmoSystem.Bullet;
using VY_CS.AmmoSystem.Magazine;
using System.Collections.Generic;

namespace VY_CS.AmmoSystem.Muzzle
{
    public class MuzzleHorizontal : MuzzleBase
    {
        private HashSet<BulletBase> _bullets = new();

        public override HashSet<BulletBase> PrepareBullets(BulletMagazine magazine)
        {
            _bullets.Clear();
            BulletBase bullet = magazine.GetBullet();

            bullet.transform.position = muzzlePosition;
            bullet.transform.rotation = Quaternion.identity;

            _bullets.Add(bullet);

            return _bullets;
        }
    }
}
