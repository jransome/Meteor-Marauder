using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Treasure treasure;

    public Treasure PickUpObject()
    {
        Debug.Log("Picking up " + treasure.name);
        Destroy(gameObject);
        return treasure;
    }
} 
