using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour {

    public Image HealthBar;
    public HitPointsManager PlayerHitPointsManager;

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        HealthBar.fillAmount = PlayerHitPointsManager.CurrentHealthPercent; 
    }
}
