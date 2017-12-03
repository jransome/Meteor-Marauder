using Assets.Scripts.Treasures;
using UnityEngine;

namespace Assets.Scripts.Asteroid
{
    public class TreasureSpawner : MonoBehaviour {

	    public Treasure TreasurePrefab;

        void OnDestroy()
        {
            SpawnTreasure();
        }
        public void SpawnTreasure()
        {
            if (TreasurePrefab != null) Instantiate(TreasurePrefab, transform.position, transform.rotation);
        }
    }
}
