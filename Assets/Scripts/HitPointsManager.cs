using UnityEngine;

public class HitPointsManager : MonoBehaviour {

    public float MaxHitPoints;
    public float StartingHitPoints;
    public float SpawnInvulnerabilityTime = 0;

    private bool isInvulnerable = false;

    #region Properties
    private float currentHitPoints = 1f;
    public float CurrentHitPoints
    {
        get { return currentHitPoints; }
        private set
        {
            currentHitPoints = value;
            if (CurrentHitPoints < 1) Die();
        }
    }

    public float CurrentHealthPercent
    {
        get { return CurrentHitPoints / MaxHitPoints; }
    }
    #endregion

	void Start ()
    {
        CurrentHitPoints = StartingHitPoints;
        Invoke("MakeDestructable", SpawnInvulnerabilityTime);
	}

    void MakeDestructable()
    {
        isInvulnerable = true;
    }

    void TakeDamage(float amount)
    {
        CurrentHitPoints -= amount;
        //Debug.Log(gameObject.name + " damaged! HP left: " + CurrentHitPoints);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    #region Collision damage
    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollisionDamage(collision);
    }
    
    void HandleCollisionDamage(Collision2D collision)
    {
        int kineticEnergy = (int)(0.5f * collision.otherRigidbody.mass * collision.relativeVelocity.sqrMagnitude);
        TakeDamage(kineticEnergy);
    }
    #endregion

    #region Weapon damage
    void OnTriggerEnter2D(Collider2D other)
    {
        HandleWeaponDamage(other);
    }

    void HandleWeaponDamage(Collider2D weaponCollider)
    {
        Weapon weapon = weaponCollider.GetComponent<Weapon>();
        if (!weapon) return;
        TakeDamage(weapon.Damage);
    }
    #endregion
}
