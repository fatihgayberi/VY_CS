using UnityEngine;
using VY_CS.AmmoSystem.Bullet;
using VY_CS.AmmoSystem.Magazine;
using System.Collections.Generic;

namespace VY_CS.AmmoSystem.Muzzle
{
    public abstract class MuzzleBase : MonoBehaviour
    {
        public abstract HashSet<BulletBase> GetBullets(BulletMagazine magazine);
    }
}