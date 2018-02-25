using UnityEngine;

public class Shields : HitPoints {

    public Collider2D ShieldCollider;
    public SpriteRenderer ShieldSprite;
    public float FlashDuration = 0.3f;

    protected override void TakeDamageInDerrived(float amount)
    {
        FlashShield();
    }

    protected override void Destroy()
    {
        base.Destroy();
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
