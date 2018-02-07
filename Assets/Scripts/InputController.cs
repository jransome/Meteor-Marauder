using UnityEngine;

public class InputController : MonoBehaviour {

    private GameObject playerObject;
    private ShipEngines playerShipEngines;
    private WeaponsController playerShipWeapons;
    public string PlayerTagName = "Player";

	void Start ()
    {
        playerObject = GameObject.FindGameObjectWithTag(PlayerTagName);
        if (playerObject != null) GetShipComponents();
	}
	
	void Update ()
    {
        if (playerObject != null)
        {
            HandleMovementInputs();
            HandleWeaponInputs();
        }
    }

    void GetShipComponents()
    {
        playerShipEngines = playerObject.GetComponent<ShipEngines>();
        playerShipWeapons = playerObject.GetComponent<WeaponsController>();
    }

    void HandleMovementInputs()
    {
        float thrustInput = Input.GetAxisRaw("Vertical");
        playerShipEngines.ThrustInput = thrustInput;

        float steeringInput = Input.GetAxisRaw("Horizontal");
        playerShipEngines.SteeringInput = steeringInput;
    }

    void HandleWeaponInputs()
    {
        if (Input.GetButton("Fire1"))
        {
            playerShipWeapons.FirePrimary();
        }
    }
}
