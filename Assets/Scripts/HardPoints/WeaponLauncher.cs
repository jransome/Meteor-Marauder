using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.HardPoints
{
    public class WeaponLauncher : MonoBehaviour
    {
        private float cooldownPeriod;
        private float cooldownTimer;
        private Rigidbody2D parentShipRb;
        public GameObject WeaponPrefab;
        public bool ImpartShipVelocity = false;

        void Start()
        {
            cooldownPeriod = WeaponPrefab.GetComponent<Weapon>().CooldownPeriod;
            parentShipRb = GetComponentInParent<Rigidbody2D>();
        }

        void Update()
        {
            Cooldown();
        }

        public void LaunchWeapon()
        {
            if (CanFire())
            {
                InstantiateWeaponPrefab();
                cooldownTimer = cooldownPeriod;
            }
        }

        void InstantiateWeaponPrefab()
        {
            // TODO: object pooling
            GameObject weapon = Instantiate(WeaponPrefab, transform.position, transform.rotation);
            if (ImpartShipVelocity)
            {
                weapon.GetComponent<Weapon>().InheritParentVelocity(parentShipRb);
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
