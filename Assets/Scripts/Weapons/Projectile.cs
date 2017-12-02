using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Projectile : Weapon {

        public float Speed = 7f;

	    void Start ()
        {
            LaunchProjectile();
        }

        void LaunchProjectile()
        {
            weaponRb.velocity += (Vector2)transform.up * Speed;
        }
    }
}

