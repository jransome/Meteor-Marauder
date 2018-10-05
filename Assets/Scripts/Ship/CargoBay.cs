using System.Collections.Generic;
using UnityEngine;

public class CargoBay : MonoBehaviour {

    #region Singleton
    public static CargoBay instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Tried to create an instance of CargoBay but one was already found!");
            return;
        }
        instance = this;
    }
    #endregion

    public int Money { get; set; }
    public delegate void OnTreasureChanged();
    public event OnTreasureChanged onTreasureChangedCallback;
    public int capacity = 3;
    public List<TreasureObject> cargoList = new List<TreasureObject>();
    private string treasureTag = "TreasurePickup"; // TODO: look at layer masks instead

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(treasureTag)) StowTreasure(other.GetComponent<TreasurePickup>());
    }

    public void StowTreasure(TreasurePickup treasure)
    {
        if (cargoList.Count >= capacity) return;

        cargoList.Add(treasure.PickUpTreasure());

        if(onTreasureChangedCallback != null) onTreasureChangedCallback(); 
    }
}
