using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour {

    public Image HealthBar;
    public Hull PlayerHull;

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        HealthBar.fillAmount = PlayerHull.CurrentHealthPercent;
    }
}
