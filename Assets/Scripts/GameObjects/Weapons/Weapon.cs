using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Rigidbody2D weaponRb;
    public float Damage = 1;
    public float CooldownPeriod = 0.1f;

    void Awake()
    {
        weaponRb = GetComponent<Rigidbody2D>();
    }

    public void InheritParentVelocity(Rigidbody2D parentRigidbody)
    {
        weaponRb.velocity += parentRigidbody.velocity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Die();
    }

    void Die()
    {
        // TODO: object pooling
        Destroy(gameObject);
    }
}
