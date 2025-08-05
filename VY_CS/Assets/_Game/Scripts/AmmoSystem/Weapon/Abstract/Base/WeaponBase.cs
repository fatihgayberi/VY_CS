using Cysharp.Threading.Tasks;
using VY_CS.AmmoSystem.Muzzle;
using VY_CS.AmmoSystem.Magazine;

namespace VY_CS.AmmoSystem.Weapon
{
    public abstract class WeaponBase : IShootable, IWeapon
    {
        protected MuzzleBase _muzzleBase;
        protected BulletMagazine _magazine;
        private WeaponData _weaponData;
        private WeaponState _weaponState = new();

        protected WeaponBase(WeaponData weaponData)
        {
            _weaponData = weaponData;
            StartShootLoop().Forget();
        }

        public abstract void Shoot();

        private async UniTaskVoid StartShootLoop()
        {
            while (true)
            {
                for (int i = 0; i < _weaponData.weaponProperty.SerialShootBulletCount; i++)
                {
                    _weaponState.SetState(WeaponStateType.Shooting);
                    Shoot();

                    // seri atis icin timerin beklemesine gerek var mi diye kontrol ediyoruz
                    if (_weaponData.weaponProperty.SerialShootBulletCount > 1)
                    {
                        _weaponState.SetState(WeaponStateType.Idle);
                        await UniTask.Delay((int)(_weaponData.weaponProperty.SerialShootBulletWaitTime * 1000), delayTiming: PlayerLoopTiming.FixedUpdate);
                    }
                }

                // Reload time
                _weaponState.SetState(WeaponStateType.Reloading);
                await UniTask.Delay((int)(_weaponData.weaponProperty.FireRate * 1000), delayTiming: PlayerLoopTiming.FixedUpdate);
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
