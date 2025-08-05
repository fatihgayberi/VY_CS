using UnityEngine;
using Cysharp.Threading.Tasks;

namespace VY_CS.AmmoSystem.Weapon
{
    public abstract class WeaponBase : MonoBehaviour, IShootable
    {
        [SerializeField] private WeaponData weaponData;
        private WeaponState _weaponState = new();

        private void Start()
        {
            StartShootLoop().Forget();
        }

        public abstract void Shoot();

        private async UniTaskVoid StartShootLoop()
        {
            while (true)
            {
                for (int i = 0; i < weaponData.weaponProperty.SerialShootBulletCount; i++)
                {
                    _weaponState.SetState(WeaponStateType.Shooting);
                    Shoot();

                    // seri atis icin timerin beklemesine gerek var mi diye kontrol ediyoruz
                    if (weaponData.weaponProperty.SerialShootBulletCount > 1)
                    {
                        _weaponState.SetState(WeaponStateType.Idle);
                        await UniTask.Delay((int)(weaponData.weaponProperty.SerialShootBulletWaitTime * 1000), delayTiming: PlayerLoopTiming.FixedUpdate);
                    }
                }

                // Reload time
                _weaponState.SetState(WeaponStateType.Reloading);
                await UniTask.Delay((int)(weaponData.weaponProperty.FireRate * 1000), delayTiming: PlayerLoopTiming.FixedUpdate);
            }
        }
    }
}
