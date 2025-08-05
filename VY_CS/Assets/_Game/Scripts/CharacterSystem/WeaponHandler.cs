using UnityEngine;
using VY_CS.AmmoSystem;
using VY_CS.AmmoSystem.AmmoSystem;

namespace VY_CS.Character
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private AmmoFactory ammoFactory;

        private void Start()
        {
            _ = ammoFactory.CreateAmmo(AmmoType.Riffle);
        }
    }
}
