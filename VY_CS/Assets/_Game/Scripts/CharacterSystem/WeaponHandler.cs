using System;
using UnityEngine;
using VY_CS.AmmoSystem;
using VY_CS.AmmoSystem.Ammo;
using VY_CS.AmmoSystem.Weapon;
using System.Collections.Generic;

namespace VY_CS.Character
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private AmmoFactory ammoFactory;
        [SerializeField] private WeaponProperties mainWeaponProperties;

        private WeaponContainer _mainWeapon;

        private HashSet<WeaponContainer> _weaponContainers = new();

        private void Start()
        {
            _mainWeapon = new WeaponContainer();
            WeaponDataHandler.Initialize(ammoFactory.GetWeaponData(mainWeaponProperties.WeaponType));

            WeaponCreator(_mainWeapon, mainWeaponProperties);
        }

        private void WeaponCreator(WeaponContainer weaponContainer, WeaponProperties weaponProperties)
        {
            // silahi yaptik
            weaponContainer.WeaponBase = ammoFactory.CreateWeapon(weaponProperties.WeaponType);
            weaponContainer.Magazine = ammoFactory.CreateMagazine(weaponProperties.BulletType);
            weaponContainer.MuzzleBase = ammoFactory.CreateMuzzle(weaponProperties.MuzzleType);

            // sarjoru taktik
            weaponContainer.WeaponBase.AttachMagazine(weaponContainer.Magazine);

            // namluyu yerlestirdik
            weaponContainer.WeaponBase.AttachMuzzle(weaponContainer.MuzzleBase);

            _weaponContainers.Add(weaponContainer);

            weaponContainer.WeaponBase.ShootStarter();
        }

        public void UpdateMuzzle(MuzzleType muzzleType)
        {
            foreach (var item in _weaponContainers)
            {
                item.MuzzleBase = ammoFactory.CreateMuzzle(muzzleType);
                item.WeaponBase.AttachMuzzle(item.MuzzleBase);
            }
        }

        public void WeaponDuplicate()
        {
            WeaponCreator(new WeaponContainer(), mainWeaponProperties);
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
