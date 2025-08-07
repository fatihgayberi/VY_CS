using System;
using UnityEngine;
using VY_CS.AmmoSystem;
using Wonnasmith.Pooling;
using VY_CS.AmmoSystem.Ammo;
using VY_CS.AmmoSystem.Weapon;
using System.Collections.Generic;

namespace VY_CS.Character
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private Pool<VY_Character> characterVisualPool;
        [SerializeField] private AmmoFactory ammoFactory;
        [SerializeField] private WeaponProperties defaultWeaponProperties;

        private WeaponProperties _mainWeaponProperties;

        private WeaponContainer _mainWeapon;
        private List<WeaponContainer> _weaponContainers = new();

        private void OnEnable()
        {
            GameManager.Instance.GameStart += OnGameStart;
            GameManager.Instance.GameExit += OnGameExit;
        }
        private void OnDisable()
        {
            GameManager.Instance.GameStart -= OnGameStart;
            GameManager.Instance.GameExit -= OnGameExit;
        }

        private void OnGameStart()
        {
            characterVisualPool.InitialPoolObjects();

            _mainWeaponProperties = defaultWeaponProperties;
            _mainWeapon = new WeaponContainer();
            WeaponDataHandler.Initialize(ammoFactory.GetWeaponData(_mainWeaponProperties.WeaponType));

            WeaponCreator(_mainWeapon, _mainWeaponProperties);
        }
        private void OnGameExit()
        {
            foreach (var item in _weaponContainers)
            {
                item?.Magazine?.Dispose();
                item?.WeaponBase?.Dispose();
            }

            _weaponContainers?.Clear();
            characterVisualPool.AllRePoolObject();
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

            Vector3 pos = UnityEngine.Random.insideUnitCircle * 3;

            weaponContainer.WeaponBase.WeaponPosition = pos;
            var character = characterVisualPool.GetPoolObject();
            character.transform.position = pos;
            character.gameObject.SetActive(true);

            weaponContainer.WeaponBase.ShootStarter();
        }

        public void WeaponDuplicate()
        {
            WeaponCreator(new WeaponContainer(), _mainWeaponProperties);
        }

        public void UpdateMuzzle(MuzzleType muzzleType)
        {
            _mainWeaponProperties.MuzzleType = muzzleType;

            foreach (var item in _weaponContainers)
            {
                item.MuzzleBase = ammoFactory.CreateMuzzle(muzzleType);
                item.WeaponBase.AttachMuzzle(item.MuzzleBase);
            }
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
