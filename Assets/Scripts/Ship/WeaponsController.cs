using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class WeaponsController : MonoBehaviour
    {
        public WeaponLauncher PrimaryWeaponHardPoint;

        public void FirePrimary()
        {
            PrimaryWeaponHardPoint.LaunchWeapon();
        }
    }
}
