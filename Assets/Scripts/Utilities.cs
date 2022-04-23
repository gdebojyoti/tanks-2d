using UnityEngine;

namespace Tanks2D {
  public static class Utilities {
    // calculate next cell location, depending upon destination & current direction
    public static Vector2 GetNextCellLocation (Vector2 currentPosition, Direction currentDirection, Vector2 destination) {
      // determine current cell location
      Vector2 currentCellLocation = new Vector2(Mathf.Round(currentPosition.x), Mathf.Round(currentPosition.y));

      // if current cell location is too close to destination, return destination
      if (Vector2.Distance(currentCellLocation, destination) < .1) {
        return destination;
      }

      // check 3 adjacent cells (ignoring 4th cell from which GO arrived); see if they are available (i.e., they should not have unbreakable walls, water, etc)
      Vector2[] adjacentCells = new Vector2[3];
      int i = 0;
      if (currentDirection != Direction.Up) {
        // add cell which is below currentCellLocation
        adjacentCells[i] = new Vector2 (currentCellLocation.x, currentCellLocation.y - 1);
        i++;
      }
      if (currentDirection != Direction.Down) {
        // add cell which is above currentCellLocation
        adjacentCells[i] = new Vector2 (currentCellLocation.x, currentCellLocation.y + 1);
        i++;
      }
      if (currentDirection != Direction.Left) {
        // add cell which is to the right of currentCellLocation
        adjacentCells[i] = new Vector2 (currentCellLocation.x + 1, currentCellLocation.y);
        i++;
      }
      if (currentDirection != Direction.Right) {
        // add cell which is to the left of currentCellLocation
        adjacentCells[i] = new Vector2 (currentCellLocation.x - 1, currentCellLocation.y);
        i++;
      }

      // get nearest cell location
      Vector2 nearestLocation = new Vector2();
      float shortestDistance = 999999f; // dummy distance
      for (int j = 0; j < adjacentCells.Length; j++) {
        // float dist = Mathf.Abs(adjacentCells[j].x - destination.x) + Mathf.Abs(adjacentCells[j].y - destination.y);
        float dist = (adjacentCells[j] - destination).magnitude;
        
        if ((j == 0) || (shortestDistance > dist)) {
          nearestLocation = adjacentCells[j];
          shortestDistance = dist;
        }
      }

      // return new Vector2(currentCellLocation.x + 1, currentCellLocation.y);
      return nearestLocation;
    }

    public static Quaternion GetRotationFromDirection (Direction direction) {
      switch (direction) {
        case Direction.Up:
          return Quaternion.Euler(0,0,0);
        case Direction.Down:
          return Quaternion.Euler(0,0,180);
        case Direction.Left:
          return Quaternion.Euler(0,0,90);
        case Direction.Right:
          return Quaternion.Euler(0,0,270);
        default:
          return Quaternion.Euler(0,0,0);
      }
    }
  }
}