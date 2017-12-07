using Assets.Scripts.Weapons;
using UnityEngine;

public class HitPointsManager : MonoBehaviour {

    public int StartingHitPoints;

    private int currentHitPoints = 1;
    public int CurrentHitPoints { get { return currentHitPoints; }
        private set
        {
            currentHitPoints = value;
            if (CurrentHitPoints < 1) Die();
        }
    }

	void Start ()
    {
        CurrentHitPoints = StartingHitPoints;	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollisionDamage(collision);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        HandleWeaponDamage(other);
    }

    void HandleCollisionDamage(Collision2D collision)
    {
        int kineticEnergy = (int)(0.5f * collision.otherRigidbody.mass * collision.relativeVelocity.sqrMagnitude);
        TakeDamage(kineticEnergy);
    }

    void HandleWeaponDamage(Collider2D weaponCollider)
    {
        Weapon weapon = weaponCollider.GetComponent<Weapon>();
        if (!weapon) return;
        TakeDamage(weapon.Damage);
    }

    void TakeDamage(int amount)
    {
        CurrentHitPoints -= amount;
        //Debug.Log(gameObject.name + " damaged! HP left: " + CurrentHitPoints);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
