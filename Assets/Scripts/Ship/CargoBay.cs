using System.Collections.Generic;
using UnityEngine;

public class CargoBay : MonoBehaviour {

    private string treasureTag = "TreasurePickUp"; // TODO: look at layer masks instead
    public int capacity = 3;
    public List<Treasure> cargoList = new List<Treasure>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(treasureTag))
            StowTreasure(other);
    }

    public void StowTreasure(Collider2D treasureCollider)
    {
        if (cargoList.Count >= capacity)
            return;

        PickUp treasurePickup = treasureCollider.GetComponent<PickUp>();
        cargoList.Add(treasurePickup.PickUpObject());
    }
}
