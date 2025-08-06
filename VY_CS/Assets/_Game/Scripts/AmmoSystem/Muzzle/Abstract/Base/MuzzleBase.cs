using System;
using VY_CS.AmmoSystem.Bullet;
using VY_CS.AmmoSystem.Magazine;
using System.Collections.Generic;
using UnityEngine;

namespace VY_CS.AmmoSystem.Muzzle
{
    [Serializable]
    public abstract class MuzzleBase : IMuzzle
    {
        public abstract HashSet<BulletBase> PrepareBullets(BulletMagazine magazine, Vector2 weaponPosition);
    }
}