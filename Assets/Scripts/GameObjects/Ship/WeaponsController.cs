using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public WeaponLauncher PrimaryWeaponHardPoint;

    public void FirePrimary()
    {
        PrimaryWeaponHardPoint.LaunchWeapon();
    }
}

