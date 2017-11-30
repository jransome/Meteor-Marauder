using UnityEngine;

public class ShipEngines : MonoBehaviour {

    private Rigidbody2D rb;
    public float EnginePower = 10f;
    public float SteeringPower = 1.4f;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

        // Move
        float thrustInput = Input.GetAxisRaw("Vertical");
        Vector2 thrustVector = transform.up * thrustInput * EnginePower;
        rb.AddForce(thrustVector);

        // Rotate
        float steeringInput = Input.GetAxisRaw("Horizontal");
        float steeringForce = -steeringInput * SteeringPower;
        rb.AddTorque(steeringForce);
    }
}
