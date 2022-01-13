using UnityEngine;
using Tanks2D;

public class PlayerController : MonoBehaviour {
  public float moveSpeed = 5f;
  public Rigidbody2D rb;
  public Direction currentDirection;
  private const float amount = .5f;

  Vector2 movement;

  private void Start() {
    currentDirection = Direction.Up;
  }

  private void Update() {
    // check for inputs
    // movement.x = Input.GetAxisRaw("Horizontal");
    // movement.y = Input.GetAxisRaw("Vertical");

    if (Input.GetAxisRaw("Horizontal") > amount) {
      // move right
      currentDirection = Direction.Right;
      movement = new Vector2(1, 0);
      transform.localRotation = Quaternion.Euler(0,0,270);
    } else if (Input.GetAxisRaw("Horizontal") < -amount) {
      // move left
      currentDirection = Direction.Left;
      movement = new Vector2(-1, 0);
      transform.localRotation = Quaternion.Euler(0,0,90);
    } else if (Input.GetAxisRaw("Vertical") > amount) {
      // move up
      currentDirection = Direction.Up;
      movement = new Vector2(0, 1);
      transform.localRotation = Quaternion.Euler(0,0,0);
    } else if (Input.GetAxisRaw("Vertical") < -amount) {
      // move down
      currentDirection = Direction.Down;
      movement = new Vector2(0, -1);
      transform.localRotation = Quaternion.Euler(0,0,180);
    } else {
      movement = new Vector2(0, 0);
    }

    transform.localRotation = Utilities.GetRotationFromDirection(currentDirection);

    // check for "interact"
    if (Input.GetKeyDown(KeyCode.F)) {
      _Fire();
    }
  }

  private void FixedUpdate() {
    // perform movement
    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
  }

  private void _Fire () {
    float col = Mathf.Floor(rb.position.x);
    float row = Mathf.Floor(rb.position.y);
    Debug.Log("fired!" + col + " " + row);
  }
}