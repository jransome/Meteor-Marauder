using Assets.Scripts.Treasures;
using UnityEngine;

namespace Assets.Scripts.Asteroid
{
    public class TreasureSpawner : MonoBehaviour {

        private bool isAppQuitting = false;
        public Treasure TreasurePrefab;

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
}
