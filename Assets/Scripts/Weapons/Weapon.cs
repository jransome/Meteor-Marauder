using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        protected Rigidbody2D weaponRb;
        public int Damage = 1;
        public float CooldownPeriod = 0.1f;

        void Awake()
        {
            weaponRb = GetComponent<Rigidbody2D>();
        }

        public void InheritParentVelocity(Rigidbody2D parentRigidbody)
        {
            weaponRb.velocity += parentRigidbody.velocity;
        }
    }
}