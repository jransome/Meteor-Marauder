using System.Collections.Generic;
using Assets.Scripts.Treasures;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class CargoBay : MonoBehaviour {

        private string treasureTag = "Treasure";
        public int Capacity = 3;
        public List<Treasure> Cargo = new List<Treasure>();

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == treasureTag) StowTreasure(other);
        }

        void StowTreasure(Collider2D treasureCollider)
        {
            if(Cargo.Count < Capacity)
            {
                Treasure treasure = treasureCollider.GetComponent<Treasure>();
                Cargo.Add(treasure);
            }
        }
    }
}
