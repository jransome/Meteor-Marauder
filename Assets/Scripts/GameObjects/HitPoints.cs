using System;
using UnityEngine;

public class HitPoints : MonoBehaviour {

    public string Name;
    public float MaxHitPoints;
    public float StartingHitPoints;
    public float SpawnInvulnerabilityTime = 0;

    /// <summary>
    /// Creates the DestroyedEvent event. This Action is equivalent to:
    ///     public delegate void DestroyedDelegate();
    ///     public event DestroyedDelegate DestroyedEvent; // event keyword is not strictly necessary but ensures 1) that subscriptions to this event cannot be overwritten in other classes (using = instead of +=), and 2) that other classes can't invoke this event 
    /// </summary>
    public Action DestroyedEvent;

    private float currentHitPoints;
    private bool destroyed = false;

    #region Properties
    public bool IsInvulnerable { get; private set; }
    public bool Destroyed
    {
        get { return destroyed; }
        set
        {
            destroyed = value;
            if (destroyed && DestroyedEvent != null)
                DestroyedEvent();
        }
    }

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
