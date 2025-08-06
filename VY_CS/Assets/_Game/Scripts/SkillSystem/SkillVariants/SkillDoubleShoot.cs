using VY_CS.AmmoSystem.Weapon;

namespace VY_CS.SkillSystem
{
    // ■ Atılan mermilerin hepsini peş peşe iki mermi olarak fırlatır.

    public class SkillDoubleShoot : SkillBase
    {
        public override void Activate()
        {
            WeaponDataHandler.WeaponPropertyController.Increase(WeaponPropertyType.SerialShootBulletCount, 1f);
        }
    }
}
