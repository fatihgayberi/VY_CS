using VY_CS.AmmoSystem.Magazine;
using VY_CS.AmmoSystem.Muzzle;

namespace VY_CS.AmmoSystem.Weapon
{
    public interface IWeapon
    {
        public void AttachMagazine(BulletMagazine magazine);
        public void AttachMuzzle(MuzzleBase muzzleBase);
    }
}