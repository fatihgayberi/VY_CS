using System;
using VY_CS.AmmoSystem.Magazine;
using VY_CS.AmmoSystem.Muzzle;
using VY_CS.AmmoSystem.Weapon;

namespace VY_CS.Character
{
    [Serializable]
    public class WeaponContainer
    {
        public WeaponBase WeaponBase;
        public MuzzleBase MuzzleBase;
        public BulletMagazine Magazine;
    }
}