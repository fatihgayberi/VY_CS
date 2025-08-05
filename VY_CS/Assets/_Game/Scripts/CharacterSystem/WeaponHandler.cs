using System;
using UnityEngine;
using VY_CS.AmmoSystem;
using VY_CS.AmmoSystem.Muzzle;
using VY_CS.AmmoSystem.Weapon;
using VY_CS.AmmoSystem.Magazine;
using VY_CS.AmmoSystem.AmmoSystem;

namespace VY_CS.Character
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private AmmoFactory ammoFactory;
        [SerializeField] private DefaultWeaponProperties defaultWeaponProperties;

        private WeaponBase _weaponBase;
        private MuzzleBase _muzzleBase;
        private BulletMagazine _magazine;

        private void Start()
        {
            // silahi yaptik
            _weaponBase = ammoFactory.CreateWeapon(defaultWeaponProperties.WeaponType);
            _magazine = ammoFactory.CreateMagazine(defaultWeaponProperties.BulletType);
            _muzzleBase = ammoFactory.CreateMuzzle(defaultWeaponProperties.MuzzleType);

            // sarjoru taktik
            _weaponBase.AttachMagazine(_magazine);

            // namluyu yerlestirdik
            _weaponBase.AttachMuzzle(_muzzleBase);
        }

        [Serializable]
        private struct DefaultWeaponProperties
        {
            public WeaponType WeaponType;
            public BulletType BulletType;
            public MuzzleType MuzzleType;
        }
    }
}
