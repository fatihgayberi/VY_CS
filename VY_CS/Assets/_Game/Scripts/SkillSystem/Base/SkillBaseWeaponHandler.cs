using VY_CS.AmmoSystem;
using VY_CS.Character;

namespace VY_CS.SkillSystem
{
    public abstract class SkillBaseWeaponHandler : SkillBase
    {
        protected WeaponHandler _weaponHandler;

        public SkillBaseWeaponHandler(WeaponHandler weaponHandler)
        {
            _weaponHandler = weaponHandler;
        }
    }
}
