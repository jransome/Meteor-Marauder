using UnityEngine;

public class CargoBayUI : MonoBehaviour {

    CargoBay cargoBay;

	void Start () {
        cargoBay = CargoBay.instance;
        cargoBay.onTreasureChangedCallback += UpdateUI;
	}

	void Update () {
		
	}

    void UpdateUI()
    {
        Debug.Log("update ui");
    }
}
