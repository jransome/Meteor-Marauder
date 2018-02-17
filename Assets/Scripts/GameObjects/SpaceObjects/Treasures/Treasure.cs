using UnityEngine;

[CreateAssetMenu(fileName = "New Treasure", menuName = "CargoBay/Item")]
public class Treasure : ScriptableObject
{
    new public string name = "Gold"; // new because scriptable object already has a name
    public int value = 10;
    public Sprite icon = null;
}
