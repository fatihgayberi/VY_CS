using Wonnasmith.Pooling;
using VY_CS.AmmoSystem.Bullet;

namespace VY_CS.AmmoSystem.Magazine
{
    public class BulletMagazine : IBulletMagazine
    {
        private Pool<BulletBase> _bulletPool;

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
            return bullet;
        }

        private void BulletReturnToPool(BulletBase bullet)
        {
            bullet.BulletLifeFinished -= BulletReturnToPool;

            _bulletPool?.RePoolObject(bullet);
        }
    }
}