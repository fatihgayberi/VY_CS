using UnityEngine;
using VY_CS.AmmoSystem.Bullet;
using VY_CS.AmmoSystem.Magazine;
using System.Collections.Generic;

namespace VY_CS.AmmoSystem.Muzzle
{
    public class MuzzleAngular : MuzzleBase
    {
        [SerializeField] private int angle = 60;         // Toplam açı yayılımı
        [SerializeField] private int angleCount = 5;     // Kaç mermi atılacak

        private HashSet<BulletBase> _bullets = new();

        public override HashSet<BulletBase> PrepareBullets(BulletMagazine magazine)
        {
            _bullets.Clear();

            float angleStep = angleCount > 1 ? (float)angle / (angleCount - 1) : 0f;
            float startAngle;

            if (angleCount % 2 == 1)
            {
                // Tek sayida -> Ortadan basla
                startAngle = -angle / 2f;
            }
            else
            {
                // Cift sayıda -> Ortada mermi yok
                startAngle = -angle / 2f + angleStep / 2f;
            }

            for (int i = 0; i < angleCount; i++)
            {
                BulletBase bullet = magazine.GetBullet();

                bullet.transform.position = muzzlePosition;
                bullet.transform.rotation = Quaternion.Euler(0, 0, startAngle + i * angleStep);

                _bullets.Add(bullet);
            }

            return _bullets;
        }
    }
}
