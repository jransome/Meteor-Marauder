using UnityEngine;

namespace Assets.Scripts.SpaceObjects
{
    public class RandomMovement : MonoBehaviour {

        private Rigidbody2D rb;
        public float MaxStartingVelocity = 2f;
        public float MinStartingVelocity = -2f;
        public float MaxStartingAngularVelocity = 1f;

	    void Start ()
        {
            rb = GetComponent<Rigidbody2D>();
            CreateRandomMotion();
	    }

        void CreateRandomMotion()
        {
            // Add random angular velocity
            float steeringForce = Random.Range(-MaxStartingAngularVelocity, MaxStartingAngularVelocity);
            rb.AddTorque(steeringForce, ForceMode2D.Impulse);

            // Add random forward velocity
            float initialForce = Random.Range(MinStartingVelocity, MaxStartingVelocity);
            Vector2 initialForceVector = transform.up * initialForce;
            rb.AddForce(initialForceVector, ForceMode2D.Impulse);
        }
    }
}
