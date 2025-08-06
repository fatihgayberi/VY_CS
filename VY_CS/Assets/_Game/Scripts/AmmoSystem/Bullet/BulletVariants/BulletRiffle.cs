using UnityEngine;
using VY_CS.AmmoSystem.Bullet;
using VY_CS.AmmoSystem.Weapon;

namespace VY_CS.AmmoSystem.BulletVariants
{
    public class BulletRiffle : BulletBase
    {
        public override void Move()
        {
            transform.position += transform.right * WeaponDataHandler.WeaponPropertyController.GetPropertyValue(WeaponPropertyType.BulletSpeed) * Time.fixedDeltaTime;
        }
    }
}