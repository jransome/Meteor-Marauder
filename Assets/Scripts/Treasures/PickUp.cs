using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Treasure treasure;

    public Treasure PickUpObject()
    {
        Debug.Log("Picking up " + treasure.name);
        Destroy(gameObject); //destroying the gameobject, then returning something from it is probably not totally okay?
        return treasure;
    }
} 
