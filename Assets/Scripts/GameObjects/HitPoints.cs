using UnityEngine;

public class HitPoints : MonoBehaviour {

    public bool IsCritical = false;
    public float MaxHitPoints;
    public float StartingHitPoints;
    public float SpawnInvulnerabilityTime = 0;

    private float currentHitPoints = 1f;

    public delegate void DamageCallback(float amount); 
    public event DamageCallback OnDamaged; 
    public delegate void DestroyedCallback();
    public event DestroyedCallback OnDestroyed; 

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
            {
                currentHitPoints = value;
                return;
            }
            if (OnDestroyed != null) OnDestroyed();
            Destroy();
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
        CurrentHitPoints -= amount;
        if (OnDamaged != null) OnDamaged(amount);
    }

    protected virtual void Destroy()
    {
        Destroyed = true;
        if (IsCritical) Destroy(gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Destroyed || IsInvulnerable) return;
        int kineticEnergy = (int)(0.5f * collision.otherRigidbody.mass * collision.relativeVelocity.sqrMagnitude);
        TakeDamage(kineticEnergy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Destroyed || IsInvulnerable) return;
        Weapon weapon = other.GetComponent<Weapon>();
        if (!weapon) return;
        TakeDamage(weapon.Damage);
    }
}
