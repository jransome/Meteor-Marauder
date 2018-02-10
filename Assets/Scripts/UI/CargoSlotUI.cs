using UnityEngine;
using UnityEngine.UI;

public class CargoSlotUI : MonoBehaviour {

    public Image icon;
    private Treasure treasure;

    public void AddTreasure(Treasure newTreasure)
    {
        treasure = newTreasure;

        icon.sprite = treasure.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        treasure = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
