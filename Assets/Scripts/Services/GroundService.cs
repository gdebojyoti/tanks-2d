using UnityEngine;

public class GroundService : MonoBehaviour {
  public SO_Level level;
  public GameObject blockPrefab;

  private void Start() {
    Debug.Log("block" + level.cells.Length);
    _Initialize();
  }

  private void _Initialize () {
    for (int i = 0; i < level.cells.Length; i++) {
      Cell cell = level.cells[i];
      var newBlock = Instantiate(blockPrefab, new Vector2(cell.rowId, cell.columnId), Quaternion.identity);
      newBlock.transform.parent = gameObject.transform;

      SpriteRenderer sr = newBlock.GetComponent<SpriteRenderer>();
      Debug.Log(sr.sprite);
      Debug.Log(cell.block.texture);
      sr.sprite = cell.block.texture;
    }
  }
}