namespace VY_CS.AmmoSystem.Weapon
{
    public static class WeaponDataHandler
    {
        private static WeaponPropertyController _weaponPropertyController;
        public static WeaponPropertyController WeaponPropertyController => _weaponPropertyController;

        public static void Initialize(WeaponData weaponData)
        {
            _weaponPropertyController = new WeaponPropertyController(weaponData.weaponProperty);
        }
    }
}