using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class ShipEngines : MonoBehaviour {

        private Rigidbody2D rb;
        public float EnginePower = 10f;
        public float SteeringPower = 1.4f;

        public float ThrustInput { get; set; }
        public float SteeringInput { get; set; }

        void Start ()
        {
            rb = GetComponent<Rigidbody2D>();
	    }

        void FixedUpdate()
        {
            Thrust();
            Steer();
        }

        void Thrust()
        {
            Vector2 thrustVector = transform.up * ThrustInput * EnginePower;
            rb.AddForce(thrustVector);
        }

        void Steer()
        {
            float steeringForce = -SteeringInput * SteeringPower;
            rb.AddTorque(steeringForce);
        }
    }
}
