using UnityEngine;
using VY_CS.AmmoSystem.Magazine;
using VY_CS.AmmoSystem.Weapon;

namespace VY_CS.AmmoSystem.AmmoSystem
{
    public class AmmoFactory : MonoBehaviour
    {
        [SerializeField] private WeaponData weaponData;
        [SerializeField] private BulletMagazine bulletMagazine;

        public WeaponBase CreateAmmo(AmmoType AmmoType)
        {
            return AmmoType switch
            {
                // AmmoType.Riffle => new WeaponRiffle(bulletMagazine, weaponData),
                _ => null
            };
        }
    }
}