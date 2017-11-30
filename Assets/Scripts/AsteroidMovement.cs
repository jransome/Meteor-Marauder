using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    private Rigidbody2D rb;
    public float MaxStartingVelocity = 2f;
    public float MinStartingVelocity = -2f;
    public float StartingRotationRange = 1f;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        CreateRandomMotion();
	}

    void CreateRandomMotion()
    {
        // Add random angular velocity
        float steeringForce = Random.Range(-StartingRotationRange, StartingRotationRange);
        rb.AddTorque(steeringForce, ForceMode2D.Impulse);

        // Add random forward velocity
        float initialForce = Random.Range(MinStartingVelocity, MaxStartingVelocity);
        Vector2 initialForceVector = transform.up * initialForce;
        rb.AddForce(initialForceVector, ForceMode2D.Impulse);
    }


}
