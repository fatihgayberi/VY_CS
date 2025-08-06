using System;
using System.Reflection;
using System.Collections.Generic;

namespace VY_CS.AmmoSystem.Weapon
{
    [Serializable]
    public class WeaponPropertyController
    {
        private WeaponProperty _baseValue;
        private WeaponProperty _multipler;

        private static readonly Dictionary<WeaponPropertyType, FieldInfo> _fieldInfoCache = new();

        public WeaponPropertyController(WeaponProperty baseValue)
        {
            _baseValue = baseValue;
            _multipler = new WeaponProperty();
        }

        /// <summary> Base + multipler toplamı doner </summary>
        public float GetPropertyValue(WeaponPropertyType weaponPropertyType)
        {
            var field = GetFieldInfo(weaponPropertyType);

            float baseVal = (float)field.GetValue(_baseValue);
            float multVal = (float)field.GetValue(_multipler);

            return baseVal + multVal;
        }

        /// <summary> Base + multipler toplamı doner </summary>
        public float GetPropertyValueBase(WeaponPropertyType weaponPropertyType)
        {
            var field = GetFieldInfo(weaponPropertyType);

            float baseVal = (float)field.GetValue(_baseValue);

            return baseVal;
        }

        /// <summary> Multipler'ı artırır </summary>
        public void Increase(WeaponPropertyType weaponPropertyType, float value)
        {
            var field = GetFieldInfo(weaponPropertyType);

            float current = (float)field.GetValue(_multipler);

            field.SetValue(_multipler, current + value);
        }

        /// <summary> Multipler'ı azaltır </summary>
        public void Decrease(WeaponPropertyType weaponPropertyType, float value)
        {
            Increase(weaponPropertyType, -value);
        }

        private FieldInfo GetFieldInfo(WeaponPropertyType weaponPropertyType)
        {
            if (_fieldInfoCache.TryGetValue(weaponPropertyType, out var cachedField)) return cachedField;

            string propertyName = WeaponPropertyNames.GetPropertyName(weaponPropertyType);
            var field = typeof(WeaponProperty).GetField(propertyName, BindingFlags.Public | BindingFlags.Instance)
                ?? throw new ArgumentException($"'{propertyName}' isminde bir alan bulunamadi.");

            _fieldInfoCache[weaponPropertyType] = field;

            return field;
        }

        public static class WeaponPropertyNames
        {
            public static string GetPropertyName(WeaponPropertyType weaponPropertyType)
            {
                if (weaponPropertyNames.TryGetValue(weaponPropertyType, out string propertyName)) return propertyName;
                throw new ArgumentOutOfRangeException(nameof(weaponPropertyType), weaponPropertyType, null);
            }

            private static readonly Dictionary<WeaponPropertyType, string> weaponPropertyNames = new()
            {
                { WeaponPropertyType.FireRate, "FireRate" },
                { WeaponPropertyType.SerialShootBulletCount, "SerialShootBulletCount" },
                { WeaponPropertyType.SerialShootBulletWaitTime, "SerialShootBulletWaitTime" },
                { WeaponPropertyType.BulletSpeed, "BulletSpeed" }
            };
        }
    }

    public enum WeaponPropertyType
    {
        NONE = 0,

        FireRate = 1,
        SerialShootBulletCount = 2,
        SerialShootBulletWaitTime = 3,
        BulletSpeed = 4
    }
}
