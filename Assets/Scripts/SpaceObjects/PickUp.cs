using Assets.Scripts.SpaceObjects.Treasures;
using UnityEngine;

namespace Assets.Scripts.SpaceObjects
{
    public class PickUp : MonoBehaviour
    {
        public Treasure treasure;

        public void PickUpObject()
        {
            Debug.Log("Picking up " + treasure.name);
            Destroy(gameObject);
        }
    } 
}
