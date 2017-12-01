using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.HardPoints
{
    public class WeaponLauncher : MonoBehaviour
    {
        private float cooldownPeriod;
        private float cooldownTimer;
        public GameObject WeaponPrefab;

        void Start()
        {
            cooldownPeriod = WeaponPrefab.GetComponent<Weapon>().CooldownPeriod;
        }

        void Update()
        {
            Cooldown();
        }

        public void LaunchWeapon()
        {
            if (CanFire())
            {
                Instantiate(WeaponPrefab, transform.position, transform.rotation);
                cooldownTimer = cooldownPeriod;
            }
        }

        bool CanFire()
        {
            return cooldownTimer <= 0;
        }

        void Cooldown()
        {
            if (!CanFire()) cooldownTimer -= Time.deltaTime;
        }
    }
}
