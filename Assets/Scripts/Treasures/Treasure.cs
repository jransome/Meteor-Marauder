using UnityEngine;

namespace Assets.Scripts.Treasures
{
    public class Treasure : MonoBehaviour
    {
        public string Name = "Gold";
        public int Value = 10;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Die();
            }
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}
