public class Hull : HitPoints {

    protected override void TakeDamageInDerrived(float amount)
    {
        //Debug.Log(gameObject.name + ": hull damaged");
    }

    protected override void Destroy()
    {
        base.Destroy();
        Destroy(gameObject);
    }
}
