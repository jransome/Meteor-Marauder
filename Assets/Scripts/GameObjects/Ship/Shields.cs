using UnityEngine;

public class Shields : MonoBehaviour {
    public HitPoints hitPoints;
    public Collider2D ShieldCollider;
    public SpriteRenderer ShieldSprite;
    public float FlashDuration = 0.3f;

    void Start()
    {
        hitPoints.OnDamaged += DamageCallback;
        hitPoints.OnDestroyed += DestroyedCallback;
    }

    void DamageCallback(float amount)
    {
        FlashShield();
    }

    void DestroyedCallback()
    {
        DisableShields();
    }

    public void DisableShields()
    {
        ShieldCollider.enabled = false;
    }

    void FlashShield()
    {
        ToggleShieldVFX();
        Invoke("ToggleShieldVFX", FlashDuration);
    }

    void ToggleShieldVFX()
    {
        ShieldSprite.enabled = !ShieldSprite.enabled;
    }
}
