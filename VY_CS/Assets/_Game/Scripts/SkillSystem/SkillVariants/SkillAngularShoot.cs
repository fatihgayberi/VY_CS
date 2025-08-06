using VY_CS.AmmoSystem;
using VY_CS.Character;

namespace VY_CS.SkillSystem
{
    // ■ İleri atılan mermilere ek olarak sağ ve sol taraflara 45 derece açı ile iki mermi daha ekler.

    public class SkillAngularShoot : SkillBaseWeaponHandler
    {
        public SkillAngularShoot(WeaponHandler weaponHandler) : base(weaponHandler) { }

        public override void Activate()
        {
            _weaponHandler.UpdateMuzzle(MuzzleType.Angular);
        }
    }
}
