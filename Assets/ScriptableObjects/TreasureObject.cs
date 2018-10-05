using UnityEngine;

[CreateAssetMenu(fileName = "New Treasure", menuName = "CargoBay/Treasure")]
public class TreasureObject : ScriptableObject
{
  new public string name = "Gold"; // new because scriptable object already has a name
  public Sprite icon = null;
  public int value = 10;
  public string Name
  {
    get { return name; }
  }

  public Sprite Icon
  {
    get { return icon; }
  }

  public int Value
  {
    get { return value; }
  }
}
