using System;
using Cysharp.Threading.Tasks;
using VY_CS.AmmoSystem.Muzzle;
using VY_CS.AmmoSystem.Magazine;
using UnityEngine;

namespace VY_CS.AmmoSystem.Weapon
{
    [Serializable]
    public abstract class WeaponBase : IShootable, IWeapon
    {
        protected MuzzleBase _muzzleBase;
        protected BulletMagazine _magazine;
        private WeaponState _weaponState = new();
        protected Vector2 weaponPosition;

        private string _weaponName;

        public void ShootStarter()
        {
            _weaponName = Guid.NewGuid().ToString();
            weaponPosition = UnityEngine.Random.insideUnitCircle * 5f;
            StartShootLoop().Forget();
        }

        public abstract void Shoot();

        private async UniTaskVoid StartShootLoop()
        {
            float serialShootBulletCount;
            float serialShootBulletWaitTime;
            float fireRate;

            while (true)
            {
                serialShootBulletCount = WeaponDataHandler.WeaponPropertyController.GetPropertyValue(WeaponPropertyType.SerialShootBulletCount);
                serialShootBulletWaitTime = WeaponDataHandler.WeaponPropertyController.GetPropertyValue(WeaponPropertyType.SerialShootBulletWaitTime);
                fireRate = WeaponDataHandler.WeaponPropertyController.GetPropertyValue(WeaponPropertyType.FireRate);

                // Debug.Log($"Serial Shoot Bullet Count: {serialShootBulletCount}, Wait Time: {serialShootBulletWaitTime}, Fire Rate: {fireRate}");

                for (int i = 0; i < serialShootBulletCount; i++)
                {
                    _weaponState.SetState(WeaponStateType.Shooting);
                    Shoot();

                    // seri atis icin timerin beklemesine gerek var mi diye kontrol ediyoruz
                    if (serialShootBulletCount > 1)
                    {
                        _weaponState.SetState(WeaponStateType.Idle);
                        await UniTask.Delay((int)(serialShootBulletWaitTime * 1000), delayTiming: PlayerLoopTiming.FixedUpdate);
                    }
                }

                // Reload time
                _weaponState.SetState(WeaponStateType.Reloading);
                await UniTask.Delay((int)(fireRate * 1000), delayTiming: PlayerLoopTiming.FixedUpdate);
            }
        }

        public void AttachMagazine(BulletMagazine magazine)
        {
            _magazine = magazine;
        }

        public void AttachMuzzle(MuzzleBase muzzleBase)
        {
            _muzzleBase = muzzleBase;
        }
    }
}
