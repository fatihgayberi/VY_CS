using UnityEngine;
using VY_CS.AmmoSystem.Bullet;
using VY_CS.AmmoSystem.Magazine;
using System.Collections.Generic;

namespace VY_CS.AmmoSystem.Muzzle
{
    public interface IMuzzle
    {
        HashSet<BulletBase> PrepareBullets(BulletMagazine magazine, Vector2 weaponPosition);
    }
}