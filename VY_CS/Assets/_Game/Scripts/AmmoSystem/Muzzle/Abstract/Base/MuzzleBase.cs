using UnityEngine;
using VY_CS.AmmoSystem.Bullet;
using VY_CS.AmmoSystem.Magazine;
using System.Collections.Generic;

namespace VY_CS.AmmoSystem.Muzzle
{
    public abstract class MuzzleBase : IMuzzle
    {
        protected Vector3 muzzlePosition;
        public abstract HashSet<BulletBase> PrepareBullets(BulletMagazine magazine);
    }
}