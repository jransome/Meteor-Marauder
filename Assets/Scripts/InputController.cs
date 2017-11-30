using UnityEngine;

public class InputController : MonoBehaviour {

    private GameObject playerObject;
    private ShipEngines playerShipEngines;
    public string PlayerTagName = "Player";

	void Start ()
    {
        playerObject = GameObject.FindGameObjectWithTag(PlayerTagName);	
        if (playerObject != null) playerShipEngines = playerObject.GetComponent<ShipEngines>();
	}
	
	void Update ()
    {
        if (playerObject != null)
        {
            HandleInputs();
        }
    }

    void HandleInputs()
    {
        float thrustInput = Input.GetAxisRaw("Vertical");
        playerShipEngines.ThrustInput = thrustInput;

        float steeringInput = Input.GetAxisRaw("Horizontal");
        playerShipEngines.SteeringInput = steeringInput;
    }
}
