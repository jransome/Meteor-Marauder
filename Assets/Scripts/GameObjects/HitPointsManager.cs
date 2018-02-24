using System.Collections.Generic;
using UnityEngine;

public class HitPointsManager : MonoBehaviour {

    private List<HitPoints> trackedHitPoints;

    public HitPoints ShieldsHP { get; private set; }
    public HitPoints HullHP { get; private set; }

    void Start()
    {
        trackedHitPoints = new List<HitPoints>(GetComponentsInChildren<HitPoints>());
        HullHP = trackedHitPoints.Find(hp => hp.Name == "HULL");
        ShieldsHP = trackedHitPoints.Find(hp => hp.Name == "SHIELD");
    }

    void Update()
    {
        if (gameObject.CompareTag("Player"))
        {
            foreach (HitPoints hp in trackedHitPoints)
            {
                Debug.Log(hp.name + ": " + hp.CurrentHitPoints);
            }
        }
    }
}
