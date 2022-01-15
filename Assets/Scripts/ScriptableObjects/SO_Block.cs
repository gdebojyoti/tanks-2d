// details of a block that can occupy a cell

using UnityEngine;

[CreateAssetMenu(fileName = "New Block", menuName = "Collections/Block")]
public class SO_Block : ScriptableObject {
  // public new string name;
  public int health;
  public SO_Block nextBlock;
  public bool canBeAttacked;
  public bool isVulnerable;
  public Sprite texture;
}