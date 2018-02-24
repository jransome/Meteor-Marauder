using UnityEngine;

public class WeaponLauncher : MonoBehaviour
{
    private float cooldownPeriod;
    private float cooldownTimer;
    private Rigidbody2D parentShipRb;
    private Collider2D[] parentShipColliders;
    public GameObject WeaponPrefab;
    public bool ImpartShipVelocity = false;

    void Start()
    {
        cooldownPeriod = WeaponPrefab.GetComponent<Weapon>().CooldownPeriod;
        parentShipRb = GetComponentInParent<Rigidbody2D>();
        parentShipColliders = transform.parent.GetComponentsInChildren<Collider2D>();
    }

    void Update()
    {
        Cooldown();
    }

    public void LaunchWeapon()
    {
        if (CanFire())
        {
            InstantiateWeaponPrefab();
            cooldownTimer = cooldownPeriod;
        }
    }

    void InstantiateWeaponPrefab()
    {
        // TODO: object pooling
        GameObject weapon = Instantiate(WeaponPrefab, transform.position, transform.rotation);

        // weapons won't collide with ship that fired them
        foreach (Collider2D parentShipCollider in parentShipColliders)
        {
            Physics2D.IgnoreCollision(weapon.GetComponent<Collider2D>(), parentShipCollider); 
        }

        if (ImpartShipVelocity) weapon.GetComponent<Weapon>().InheritParentVelocity(parentShipRb);
    }

    bool CanFire()
    {
        return cooldownTimer <= 0;
    }

    void Cooldown()
    {
        if (!CanFire()) cooldownTimer -= Time.deltaTime;
    }
}

