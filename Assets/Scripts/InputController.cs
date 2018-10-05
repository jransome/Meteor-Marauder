using UnityEngine;

public class InputController : MonoBehaviour
{
    public string PlayerTagName = "Player";
    public float MaxSteeringThreshold = 60f;
    private GameObject playerObject;
    private Engines playerShipEngines;
    private WeaponsController playerShipWeapons;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag(PlayerTagName);
        if (playerObject != null) GetShipComponents();
    }

    void GetShipComponents()
    {
        playerShipEngines = playerObject.GetComponentInChildren<Engines>();
        playerShipWeapons = playerObject.GetComponentInChildren<WeaponsController>();
    }

    void Update()
    {
        if (playerObject != null)
        {
            HandleMovementInputs();
            HandleWeaponInputs();
        }
    }

    float MouseSteeringInput()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.zero);
        Vector3 direction = mousePosition - playerObject.transform.position;
        float angle = Vector2.SignedAngle(direction, playerObject.transform.up);
        return Mathf.Clamp(angle, -MaxSteeringThreshold, MaxSteeringThreshold) / MaxSteeringThreshold;
    }

    void HandleMovementInputs()
    {
        float thrustInput = Input.GetAxisRaw("Vertical");
        playerShipEngines.ThrustInput = thrustInput;

        float strafingInput = Input.GetAxisRaw("Horizontal");
        playerShipEngines.StrafingInput = strafingInput;

        float steeringInput = MouseSteeringInput();
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
