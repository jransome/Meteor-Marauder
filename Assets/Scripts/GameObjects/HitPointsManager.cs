//using System.Collections.Generic;
//using UnityEngine;

//public class HitPointsManager : MonoBehaviour {

//    private List<HitPoints> subSystemHitPoints;

//    public HitPoints ShieldsHP { get; private set; }
//    public HitPoints HullHP { get; private set; }

//    void Start()
//    {
//        subSystemHitPoints = new List<HitPoints>(GetComponentsInChildren<HitPoints>());
//        HullHP = subSystemHitPoints.Find(hp => hp.Name == "HULL");
//        ShieldsHP = subSystemHitPoints.Find(hp => hp.Name == "SHIELD");
//        HullHP.DestroyedEvent += OnHullDestroyed;
//    }

//    void Update()
//    {
//        if (gameObject.CompareTag("Player"))
//        {
//            foreach (HitPoints hp in subSystemHitPoints)
//            {
//                Debug.Log(hp.name + ": " + hp.CurrentHitPoints);
//            }
//        }
//    }

//    void OnHullDestroyed()
//    {
//        Debug.Log("SHIP WAS DESTROYED");
//        Destroy(gameObject);
//    }
//}
