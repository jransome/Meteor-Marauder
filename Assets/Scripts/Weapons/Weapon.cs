using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public int Damage = 1;
        public float CooldownPeriod = 0.1f;
    }
}
