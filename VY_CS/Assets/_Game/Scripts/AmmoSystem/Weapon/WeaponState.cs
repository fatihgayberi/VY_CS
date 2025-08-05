using System;

namespace VY_CS.AmmoSystem.Weapon
{
    [Serializable]
    public class WeaponState
    {
        private WeaponStateType currentState = WeaponStateType.Idle;

        public void SetState(WeaponStateType newState)
        {
            if (currentState == newState) return;

            currentState = newState;

            switch (newState)
            {
                case WeaponStateType.Shooting:
                case WeaponStateType.Idle:
                case WeaponStateType.Reloading:
                    break;
            }
        }
    }
}