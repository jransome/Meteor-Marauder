using UnityEngine;

public class HitPoints : MonoBehaviour {

    public int StartingHitPoints;

    private int currentHitPoints = 1;
    public int CurrentHitPoints { get { return currentHitPoints; }
        private set
        {
            currentHitPoints = value;
            if (CurrentHitPoints < 1) Die();
        }
    }

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
        Debug.Log(gameObject.name + " damaged! HP left: " + CurrentHitPoints);
        CurrentHitPoints -= amount;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
