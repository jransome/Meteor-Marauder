using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Projectile : Weapon {

        private Rigidbody2D rb;
        public float Speed = 7f;

	    void Start ()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * Speed;
        }
    }
}

