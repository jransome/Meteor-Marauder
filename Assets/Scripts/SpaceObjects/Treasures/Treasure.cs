using UnityEngine;

namespace Assets.Scripts.SpaceObjects.Treasures
{
    [CreateAssetMenu(fileName = "New Treasure", menuName = "CargoBay/Item")]
    public class Treasure : ScriptableObject
    {
        new public string name = "Gold";
        public int value = 10;
        public Sprite icon = null;
    }
}
