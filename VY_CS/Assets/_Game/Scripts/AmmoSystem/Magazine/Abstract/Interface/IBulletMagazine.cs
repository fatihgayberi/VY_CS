using Wonnasmith.Pooling;
using VY_CS.AmmoSystem.Bullet;

namespace VY_CS.AmmoSystem.Magazine
{
    public interface IBulletMagazine
    {
        void SwitchBullet(Pool<BulletBase> bulletPool);
        BulletBase GetBullet();
    }
}