using UnityEngine;

public class CargoBayUI : MonoBehaviour {

    CargoBay cargoBay;
    CargoSlotUI[] uiSlots;

	void Start () {
        cargoBay = CargoBay.instance;
        cargoBay.onTreasureChangedCallback += UpdateUI;

        uiSlots = GetComponentsInChildren<CargoSlotUI>();
	}

    // Called when cargo bay inventory is changed
    void UpdateUI()
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            if(i < cargoBay.cargoList.Count)
            {
                uiSlots[i].AddTreasure(cargoBay.cargoList[i]);
            }
            else
            {
                uiSlots[i].ClearSlot();
            }
        }
    }
}
