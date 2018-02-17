using UnityEngine;

public class TreasureSpawner : MonoBehaviour {

    private bool isAppQuitting = false;
    public GameObject TreasurePrefab;

    void OnApplicationQuit()
    {
        isAppQuitting = true;
    }

    void OnDestroy()
    {
        if (!isAppQuitting) SpawnTreasure();
    }

    public void SpawnTreasure()
    {
        if (TreasurePrefab != null) Instantiate(TreasurePrefab, transform.position, transform.rotation);
    }
}

