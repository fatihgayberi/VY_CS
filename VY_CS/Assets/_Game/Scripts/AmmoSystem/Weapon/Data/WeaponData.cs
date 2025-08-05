using UnityEngine;

namespace VY_CS.AmmoSystem.Weapon
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "AmmoSystem/WeaponData", order = 0)]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] public WeaponProperty weaponProperty;
    }

    [System.Serializable]
    public class WeaponProperty
    {
        [SerializeField, Min(0.1f)] private float _fireRate;
        [SerializeField, Min(1)] private uint _serialShootBulletCount;
        [SerializeField, Min(0)] private float _serialShootBulletWaitTime;

        public float FireRate => _fireRate;
        public uint SerialShootBulletCount => _serialShootBulletCount;
        public float SerialShootBulletWaitTime => _serialShootBulletWaitTime;
    }
}