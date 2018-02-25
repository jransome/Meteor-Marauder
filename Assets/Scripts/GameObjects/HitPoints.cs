using UnityEngine;

public abstract class HitPoints : MonoBehaviour {

    public float MaxHitPoints;
    public float StartingHitPoints;
    public float SpawnInvulnerabilityTime = 0;

    private float currentHitPoints = 1f;

    #region Properties
    public bool IsInvulnerable { get; set; }
    public bool Destroyed { get; private set; }

    public float CurrentHealthPercent
    {
        get { return CurrentHitPoints / MaxHitPoints; }
    }

    public float CurrentHitPoints
    {
        get { return currentHitPoints; }
        private set
        {
            if (CurrentHitPoints > 0)
                currentHitPoints = value;
            if (CurrentHitPoints <= 0)
            {
                Destroy();
            }
        }
    }
    #endregion

    void Start()
    {
        IsInvulnerable = true;
        Destroyed = false;
        CurrentHitPoints = StartingHitPoints;
        Invoke("MakeDestructable", SpawnInvulnerabilityTime);
    }

    void MakeDestructable()
    {
        IsInvulnerable = false;
    }

    void TakeDamage(float amount)
    {
        if (IsInvulnerable)
            return;

        CurrentHitPoints -= amount;
        TakeDamageInDerrived(amount);
    }

    protected abstract void TakeDamageInDerrived(float amount);

    protected virtual void Destroy()
    {
        Destroyed = true;
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
