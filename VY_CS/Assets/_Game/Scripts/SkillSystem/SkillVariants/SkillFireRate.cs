using VY_CS.AmmoSystem.Weapon;

namespace VY_CS.SkillSystem
{
    // ■ Atılan mermi sıklığını artırır. (1 saniye aralıklarla atış yapmayı sağlar)

    public class SkillFireRate : SkillBase
    {
        public override void Activate()
        {
            // default deger 3 oldugu icin burada elle 2 verdim parametereyi
            WeaponDataHandler.WeaponPropertyController.Decrease(WeaponPropertyType.FireRate, 2f);
        }
    }
}
