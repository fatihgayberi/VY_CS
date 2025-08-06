using VY_CS.AmmoSystem.Weapon;

namespace VY_CS.SkillSystem
{
    // ■ Atılan mermilerin hızını yüzde 50 artırır.

    public class SkillBulletSpeed : SkillBase
    {
        public override void Activate()
        {
            float baseBulletSpeed = WeaponDataHandler.WeaponPropertyController.GetPropertyValueBase(WeaponPropertyType.BulletSpeed);
            float newBulletSpeed = baseBulletSpeed * 1.5f;

            WeaponDataHandler.WeaponPropertyController.Increase(WeaponPropertyType.BulletSpeed, newBulletSpeed);
        }
    }
}
