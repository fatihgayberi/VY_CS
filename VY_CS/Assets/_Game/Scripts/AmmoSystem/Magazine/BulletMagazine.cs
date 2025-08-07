using System;
using Wonnasmith.Pooling;
using VY_CS.AmmoSystem.Bullet;
using System.Collections.Generic;

namespace VY_CS.AmmoSystem.Magazine
{
    [Serializable]
    public class BulletMagazine : IBulletMagazine, IDisposable
    {
        private Pool<BulletBase> _bulletPool;
        private HashSet<IBullet> activeBullets = new();

        public BulletMagazine(Pool<BulletBase> bulletPool)
        {
            _bulletPool = bulletPool;
        }

        public BulletBase GetBullet()
        {
            if (_bulletPool == null) return null;

            BulletBase bullet = _bulletPool.GetPoolObject();
            if (bullet == null) return null;

            bullet.BulletLifeFinished += BulletReturnToPool;
            activeBullets.Add(bullet);
            return bullet;
        }

        private void BulletReturnToPool(BulletBase bullet)
        {
            activeBullets.Remove(bullet);
            bullet.BulletLifeFinished -= BulletReturnToPool;
            _bulletPool?.RePoolObject(bullet);
        }

        public void Dispose()
        {
            _bulletPool.AllRePoolObject();

            foreach (var item in activeBullets)
            {
                item.BulletLifeFinished -= BulletReturnToPool;
            }
        }
    }
}