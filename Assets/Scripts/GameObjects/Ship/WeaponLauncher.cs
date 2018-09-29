using UnityEngine;

public class WeaponLauncher : MonoBehaviour
{
    private float cooldownTimer;
    private Rigidbody2D parentShipRb;
    private Collider2D[] parentShipColliders;
    public GameObject WeaponPrefab;
    public float CooldownPeriod = 0.1f;


    void Start()
    {
        parentShipRb = GetComponentInParent<Rigidbody2D>();
        parentShipColliders = transform.parent.GetComponentsInChildren<Collider2D>();
    }

    void Update()
    {
        if (!CanFire()) Cooldown();
    }

    public void LaunchWeapon()
    {
        if (!CanFire()) return;

        Weapon weapon = Instantiate(
            WeaponPrefab,
            transform.position,
            transform.rotation).GetComponent<Weapon>(); // TODO: object pooling

        // weapons won't collide with ship that fired them. TODO: set a timeout for this and also make this a weapon responsibility?
        foreach (Collider2D parentShipCollider in parentShipColliders)
        {
            Physics2D.IgnoreCollision(weapon.GetComponent<Collider2D>(), parentShipCollider);
        }

        weapon.Launch(parentShipRb);

        cooldownTimer = CooldownPeriod;
    }

    bool CanFire()
    {
        return cooldownTimer <= 0;
    }

    void Cooldown()
    {
        cooldownTimer -= Time.deltaTime;
    }
}

