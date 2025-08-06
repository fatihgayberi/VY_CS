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
        [SerializeField] private WeaponProperties defaultWeaponProperties;

        private WeaponBase _weaponBase;
        private MuzzleBase _muzzleBase;
        private BulletMagazine _magazine;

        private WeaponProperties _currentWeaponProperties;


        private void Start()
        {
            _currentWeaponProperties = defaultWeaponProperties;

            WeaponDataHandler.Initialize(ammoFactory.GetWeaponData(_currentWeaponProperties.WeaponType));

            // silahi yaptik
            _weaponBase = ammoFactory.CreateWeapon(_currentWeaponProperties.WeaponType);
            _magazine = ammoFactory.CreateMagazine(_currentWeaponProperties.BulletType);
            _muzzleBase = ammoFactory.CreateMuzzle(_currentWeaponProperties.MuzzleType);

            // sarjoru taktik
            _weaponBase.AttachMagazine(_magazine);

            // namluyu yerlestirdik
            _weaponBase.AttachMuzzle(_muzzleBase);
        }

        private void UpdateMuzzle(MuzzleType muzzleType)
        {
            _muzzleBase = ammoFactory.CreateMuzzle(muzzleType);
            _weaponBase.AttachMuzzle(_muzzleBase);
        }

        [Serializable]
        private struct WeaponProperties
        {
            public WeaponType WeaponType;
            public BulletType BulletType;
            public MuzzleType MuzzleType;
        }
    }
}
