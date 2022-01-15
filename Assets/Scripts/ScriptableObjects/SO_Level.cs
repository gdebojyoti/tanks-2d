using UnityEngine;

[CreateAssetMenu(fileName = "New level", menuName = "Collections/Level", order = 0)]
public class SO_Level : ScriptableObject {
  public Cell[] cells;
}
