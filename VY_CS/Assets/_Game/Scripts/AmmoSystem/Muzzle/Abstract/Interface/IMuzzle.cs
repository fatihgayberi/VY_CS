using System.Collections.Generic;
using VY_CS.AmmoSystem.Bullet;
using VY_CS.AmmoSystem.Magazine;

namespace VY_CS.AmmoSystem.Muzzle
{
    public interface IMuzzle
    {
        HashSet<BulletBase> PrepareBullets(BulletMagazine magazine);
    }
}