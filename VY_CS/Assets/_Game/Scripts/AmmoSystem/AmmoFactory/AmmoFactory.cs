using System;
using UnityEngine;
using Wonnasmith.Pooling;
using VY_CS.AmmoSystem.Bullet;
using VY_CS.AmmoSystem.Weapon;
using VY_CS.AmmoSystem.Muzzle;
using VY_CS.AmmoSystem.Magazine;

namespace VY_CS.AmmoSystem.Ammo
{
    public class AmmoFactory : MonoBehaviour
    {
        [SerializeField] private WeaponData[] weaponData;
        [SerializeField] private BulletPoolData[] bulletPoolData;

        public WeaponBase CreateWeapon(WeaponType weaponType)
        {
            return weaponType switch
            {
                WeaponType.Riffle => new WeaponRiffle(),
                _ => null
            };
        }

        public WeaponData GetWeaponData(WeaponType weaponType)
        {
            foreach (var data in weaponData)
            {
                if (data.weaponType != weaponType) continue;
                return data;
            }
            return null;
        }

        public BulletMagazine CreateMagazine(BulletType bulletType)
        {
            return new BulletMagazine(CreateBulletPool(bulletType));
        }

        private Pool<BulletBase> CreateBulletPool(BulletType bulletType)
        {
            foreach (var item in bulletPoolData)
            {
                if (item.BulletType != bulletType) continue;
                item.BulletPool.InitialPoolObjects();
                return item.BulletPool;
            }

            return null;
        }

        internal MuzzleBase CreateMuzzle(MuzzleType muzzleType)
        {
            return muzzleType switch
            {
                MuzzleType.Horizontal => new MuzzleHorizontal(),
                MuzzleType.Angular => new MuzzleAngular(),
                _ => null
            };
        }

        [Serializable]
        partial class BulletPoolData
        {
            public BulletType BulletType;
            public Pool<BulletBase> BulletPool;
        }
    }
}