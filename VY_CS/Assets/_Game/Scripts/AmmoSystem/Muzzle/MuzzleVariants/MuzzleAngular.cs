using UnityEngine;
using VY_CS.AmmoSystem.Bullet;
using VY_CS.AmmoSystem.Magazine;
using System.Collections.Generic;

namespace VY_CS.AmmoSystem.Muzzle
{
    public class MuzzleAngular : MuzzleBase
    {
        private int _angle = 45;
        private int _angleCount = 2;

        private HashSet<BulletBase> _bullets = new();

        public override HashSet<BulletBase> PrepareBullets(BulletMagazine magazine, Vector2 weaponPosition)
        {
            _bullets.Clear();

            int buletCount = _angleCount + 1;
            float angleStep = buletCount > 1 ? (float)_angle / (buletCount - 1) : 0f;
            float startAngle;

            if (buletCount % 2 == 1)
            {
                // Tek sayida -> Ortadan basla
                startAngle = -_angle / 2f;
            }
            else
            {
                // Cift sayıda -> Ortada mermi yok
                startAngle = -_angle / 2f + angleStep / 2f;
            }

            for (int i = 0; i < buletCount; i++)
            {
                BulletBase bullet = magazine.GetBullet();

                bullet.transform.position = weaponPosition;
                bullet.transform.rotation = Quaternion.Euler(0, 0, startAngle + i * angleStep);

                _bullets.Add(bullet);
            }

            return _bullets;
        }
    }
}
