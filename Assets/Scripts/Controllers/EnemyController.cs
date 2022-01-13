using UnityEngine;
using System.Collections;
using Tanks2D;

public class EnemyController : MonoBehaviour {
  // public Vector2 spawnLocation;
  public Vector2 destination; // target destination that enemy has to reach
  public Vector2 nextCellLocation = new Vector2(-6, 3);
  public Direction currentDirection;
  public float moveSpeed = 2f;
  public bool canMove = false; // wait for .2s to prevent the jerk at the start
  public GameObject destinationGo; // GO for destination location; for debugging

  private void Start() {
    Debug.Log("Enemy spawned!" + transform.position);
    currentDirection = Direction.Down; // set direction to Down
    transform.localRotation = Quaternion.Euler(0,0,180); // update enemy icon
  }

  private void Awake() {
    StartCoroutine(_WaitForWarmup());
  }

  private void Update() {
    // NOTE: click anywhere to set enemy destination; for debugging
    if (Input.GetMouseButtonDown(0)) {
      Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      destination = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
      destinationGo.transform.position = destination;
		}
  }

  private void FixedUpdate() {
    if (canMove)
      _MoveTowardsDestination();
  }

  // wait for .2s to prevent the jerk at the start
  IEnumerator _WaitForWarmup() {
    yield return new WaitForSeconds(.2f);
    canMove = true;
  }

  private void _MoveTowardsDestination () {
    // determine current position
    Vector2 pos = transform.position;
    // calculate distance from nextCellLocation
    float dist = Vector2.Distance(pos, nextCellLocation);
    // if distance less than limit, update nextCellLocation
    if (dist < .1) {
      _GetNextCellLocation();
    }
    // move towards nextCellLocation
    _MoveTowardsNextCell();
  }

  private void _GetNextCellLocation () {
    Vector2 newLocation = Utilities.GetNextCellLocation(transform.position, currentDirection, destination);

    Vector2 n = newLocation - nextCellLocation;
    n.Normalize();
    n = new Vector2(Mathf.Round(n.x), Mathf.Round(n.y));
    Debug.Log("normalized" + (n == new Vector2(1f, 0)));
    if (n == new Vector2(1f, 0)) {
      currentDirection = Direction.Right;
    } else if (n == new Vector2(-1f, 0)) {
      currentDirection = Direction.Left;
    } else if (n == new Vector2(0, 1f)) {
      currentDirection = Direction.Up;
    } else if (n == new Vector2(0, -1f)) {
      currentDirection = Direction.Down;
    }
    nextCellLocation = newLocation;
    transform.localRotation = Utilities.GetRotationFromDirection(currentDirection);
  }

  private void _MoveTowardsNextCell() {
    transform.position = Vector2.MoveTowards(transform.position, nextCellLocation, moveSpeed * Time.fixedDeltaTime);
  }
}