using UnityEngine;
using UnityEngine.UI;

public class CargoSlotUI : MonoBehaviour {

    public Image Icon;
    private TreasureObject treasure;

    public void AddTreasure(TreasureObject newTreasure)
    {
        treasure = newTreasure;
Debug.Log(newTreasure.Icon);
        Icon.sprite = treasure.Icon;
        Icon.enabled = true;
    }

    public void ClearSlot()
    {
        treasure = null;

        Icon.sprite = null;
        Icon.enabled = false;
    }
}
