using UnityEngine;

namespace Assets.Scripts.Treasures
{
    public class Treasure : MonoBehaviour
    {
        public string Name = "Gold";
        public int Value = 10;

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}
