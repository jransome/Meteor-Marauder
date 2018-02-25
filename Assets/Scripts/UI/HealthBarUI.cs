using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour {

    public Image HealthBar;
    public HitPoints HitPointsThingToTrack;

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        HealthBar.fillAmount = HitPointsThingToTrack.CurrentHealthPercent;
    }
}
