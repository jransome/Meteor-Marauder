using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float Damage = 1;
    public float MinSpeed = 7f;
    private Rigidbody2D weaponRb;

    void Awake()
    {
        weaponRb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Rigidbody2D parentRigidbody)
    {
        float impartedVelocity = MinSpeed + Vector2.Dot(parentRigidbody.velocity, transform.up);
        float velocity = impartedVelocity < MinSpeed ? MinSpeed : impartedVelocity;
        weaponRb.velocity = (Vector2)transform.up * velocity;
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
