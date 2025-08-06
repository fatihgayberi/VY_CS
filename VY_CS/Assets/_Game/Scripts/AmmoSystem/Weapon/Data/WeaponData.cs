using UnityEngine;

namespace VY_CS.AmmoSystem.Weapon
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "AmmoSystem/WeaponData", order = 0)]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] public WeaponType weaponType;
        [SerializeField] public WeaponProperty weaponProperty;
    }

    [System.Serializable]
    public class WeaponProperty
    {
        public float FireRate;
        public float SerialShootBulletCount;
        public float SerialShootBulletWaitTime;
        public float BulletSpeed;
    }
}