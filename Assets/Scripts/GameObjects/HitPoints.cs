using UnityEngine;

public class HitPoints : MonoBehaviour {

    public string Name;
    public float MaxHitPoints;
    public float StartingHitPoints;
    public float SpawnInvulnerabilityTime = 0;

    private float currentHitPoints;

    #region Properties
    public bool IsInvulnerable { get; private set; }
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
            currentHitPoints = value;
            if (CurrentHitPoints <= 0) Destroyed = true;
        }
    }
    #endregion

    void Start()
    {
        CurrentHitPoints = StartingHitPoints;
        Invoke("MakeDestructable", SpawnInvulnerabilityTime);
    }

    void MakeDestructable()
    {
        IsInvulnerable = false;
    }

    void TakeDamage(float amount)
    {
        if (!IsInvulnerable)
            CurrentHitPoints -= amount;
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

    public void HandleWeaponDamage(Collider2D weaponCollider)
    {
        Weapon weapon = weaponCollider.GetComponent<Weapon>();
        if (!weapon) return;
        TakeDamage(weapon.Damage);
    }
    #endregion
}
