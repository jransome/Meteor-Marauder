using UnityEngine;

public class TreasurePickup : MonoBehaviour
{
    public TreasureObject[] possibleTreasures;
    TreasureObject treasure;

    void Start() {
        treasure = possibleTreasures[Random.Range(0, possibleTreasures.Length)];
        GetComponent<SpriteRenderer>().sprite = treasure.Icon;
    }
    public TreasureObject PickUpTreasure()
    {
        Debug.Log("Picking up " + treasure.Name);
        Destroy(gameObject); //destroying the gameobject, then returning something from it is probably not totally okay?
        return treasure;
    }
} 
