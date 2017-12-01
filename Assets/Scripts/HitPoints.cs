using UnityEngine;

public class HitPoints : MonoBehaviour {

    public int StartingHitPoints;
    public int CurrentHitPoints { get; private set; }

	void Start ()
    {
        CurrentHitPoints = StartingHitPoints;	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        TakeCollisionDamage(collision);
    }
    
    void TakeCollisionDamage(Collision2D collision)
    {
        int kineticEnergy = (int)(0.5f * collision.otherRigidbody.mass * collision.relativeVelocity.sqrMagnitude);
        TakeDamage(kineticEnergy);
    }

    void TakeDamage(int amount)
    {
        Debug.Log("Damaged: " + -amount + "hp");
        CurrentHitPoints -= amount;
    }
}
