using System.Collections.Generic;
using Assets.Scripts.SpaceObjects;
using Assets.Scripts.SpaceObjects.Treasures;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class CargoBay : MonoBehaviour {

        private string treasureTag = "TreasurePickUp"; // TODO: look at layer masks instead
        public int capacity = 3;
        public List<Treasure> cargo = new List<Treasure>();

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(treasureTag)) StowTreasure(other);
        }

        void StowTreasure(Collider2D treasureCollider)
        {
            if(cargo.Count < capacity)
            {
                PickUp treasurePickup = treasureCollider.GetComponent<PickUp>();
                Treasure treasure = treasurePickup.treasure;
                cargo.Add(treasure);
                treasurePickup.PickUpObject();
            }
        }
    }
}
