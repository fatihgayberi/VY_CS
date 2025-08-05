using UnityEngine;
using Wonnasmith.Pooling;
using VY_CS.AmmoSystem.Bullet;

namespace VY_CS.AmmoSystem.Magazine
{
    public class BulletMagazine : MonoBehaviour, IBulletMagazine
    {
        [SerializeField] private Pool<BulletBase> bulletPool;

        private void Start()
        {
            if (bulletPool == null) return;
            bulletPool.InitialPoolObjects();
        }

        public BulletBase GetBullet()
        {
            if (bulletPool == null) return null;

            BulletBase bullet = bulletPool.GetPoolObject();
            if (bullet == null) return null;

            bullet.BulletLifeFinished += BulletReturnToPool;
            return bullet;
        }

        private void BulletReturnToPool(BulletBase bullet)
        {
            bullet.BulletLifeFinished -= BulletReturnToPool;

            bulletPool?.RePoolObject(bullet);
        }
    }
}