using UnityEngine;

public class Shields : HitPoints {

    protected override void TakeDamageInDerrived(float amount)
    {
        //Debug.Log(gameObject.name + ": shield damaged");
        FlashShield();
    }

    protected override void Destroy()
    {
        base.Destroy();
        Debug.Log("shields destroyed");
    }

    void FlashShield()
    {
        //Debug.Log("shield flash");
    }
}
