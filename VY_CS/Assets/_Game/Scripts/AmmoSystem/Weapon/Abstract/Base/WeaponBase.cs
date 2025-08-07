using System;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;
using VY_CS.AmmoSystem.Muzzle;
using VY_CS.AmmoSystem.Magazine;

namespace VY_CS.AmmoSystem.Weapon
{
    [Serializable]
    public abstract class WeaponBase : IShootable, IWeapon, IDisposable
    {
        protected MuzzleBase _muzzleBase;
        protected BulletMagazine _magazine;
        private WeaponState _weaponState = new();
        public Vector2 WeaponPosition;

        private CancellationTokenSource _shootCts;

        public void Dispose()
        {
            StopShooting();
        }

        public abstract void Shoot();

        public void ShootStarter()
        {
            StopShooting();

            _shootCts = new CancellationTokenSource();
            StartShootLoop(_shootCts.Token).Forget();
        }

        public void StopShooting()
        {
            if (_shootCts == null) return;
            if (_shootCts.IsCancellationRequested) return;

            _shootCts.Cancel();
            _shootCts.Dispose();
            _shootCts = null;
        }

        private async UniTaskVoid StartShootLoop(CancellationToken token)
        {
            float serialShootBulletCount;
            float serialShootBulletWaitTime;
            float fireRate;

            try
            {
                while (!token.IsCancellationRequested)
                {
                    if (WeaponDataHandler.WeaponPropertyController == null) break;

                    serialShootBulletCount = WeaponDataHandler.WeaponPropertyController.GetPropertyValue(WeaponPropertyType.SerialShootBulletCount);
                    serialShootBulletWaitTime = WeaponDataHandler.WeaponPropertyController.GetPropertyValue(WeaponPropertyType.SerialShootBulletWaitTime);
                    fireRate = WeaponDataHandler.WeaponPropertyController.GetPropertyValue(WeaponPropertyType.FireRate);

                    for (int i = 0; i < serialShootBulletCount; i++)
                    {
                        token.ThrowIfCancellationRequested();

                        _weaponState.SetState(WeaponStateType.Shooting);
                        Shoot();

                        if (serialShootBulletCount > 1)
                        {
                            _weaponState.SetState(WeaponStateType.Idle);
                            await UniTask.Delay((int)(serialShootBulletWaitTime * 1000), delayTiming: PlayerLoopTiming.FixedUpdate, cancellationToken: token);
                        }
                    }

                    _weaponState.SetState(WeaponStateType.Reloading);
                    await UniTask.Delay((int)(fireRate * 1000), delayTiming: PlayerLoopTiming.FixedUpdate, cancellationToken: token);
                }
            }
            catch (OperationCanceledException) { }
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
