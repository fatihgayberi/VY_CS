using VY_CS.Character;

namespace VY_CS.SkillSystem
{
    // ■ Ekranın farklı bir yerinde karakterimizin aynı özellikte bir kopyasını oluşturur.

    public class SkillClonePlayer : SkillBaseWeaponHandler
    {
        public SkillClonePlayer(WeaponHandler weaponHandler) : base(weaponHandler) { }

        public override void Activate()
        {
            _weaponHandler.WeaponDuplicate();
        }
    }
}
