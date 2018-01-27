using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
public bool isRoaming=false;
public int roamingDistance;
public int speed;
public bool alive;
public TileFactory tileFactory;

void Start () {
        alive = true;
        StartCoroutine(randomizeRoaming(50,1));
        tileFactory = GameObject.Find ("TileFactory").GetComponent<TileFactory>();
}

void Update () {
}

public enum Direction {UP, DOWN,
                       RIGHT, LEFT,
                       UP_RIGHT, UP_LEFT,
                       DOWN_RIGHT, DOWN_LEFT};

public Direction getDirection(PathFind.Point from, PathFind.Point to) {
        bool right = from.x < to.x;
        bool left = from.x > to.x;
        bool down = from.y < to.y;
        bool up = from.y > to.y;

        if (down && !left && !right) {
                Debug.LogWarning("should go down");
                return Direction.DOWN;
        } else if (down && left) {
                Debug.LogWarning("should go down left");
                return Direction.DOWN_LEFT;
        } else if (down && right) {
                Debug.LogWarning("should go down right");
                return Direction.DOWN_RIGHT;
        } else if (up && !left && !right) {
                Debug.Log("should go up");
                return Direction.UP;
        } else if (up && left) {
                Debug.LogWarning("should go up left");
                return Direction.UP_LEFT;
        } else if (up && right) {
                Debug.LogWarning("should go up right");
                return Direction.UP_RIGHT;
        } else if (right) {
                Debug.LogWarning("should go right");
                return Direction.RIGHT;
        } else {
                Debug.LogWarning("should go left");
                return Direction.LEFT;
        }
}

public IEnumerator roaming()
{
        bool[,] collisionMap = getCollisionMap (Level1.tilemap);

        int width = collisionMap.GetLength(0);
        int height = collisionMap.GetLength (1);
        PathFind.Grid grid = new PathFind.Grid(width, height, collisionMap);
        PathFind.Point from = new PathFind.Point(Mathf.RoundToInt(gameObject.transform.position.x),  Mathf.RoundToInt(gameObject.transform.position.y) * -1);

        PathFind.Point to = new PathFind.Point(4, 5);

        Debug.Log("length x " + Level1.tilemap.GetLength(0));
        Debug.Log("length y " + Level1.tilemap.GetLength(1));
        Debug.Log("clength x " + collisionMap.GetLength(0));
        Debug.Log("clength y " + collisionMap.GetLength(1));
        Debug.Log("glength x " + grid.nodes.GetLength(0));
        Debug.Log("glength y " + grid.nodes.GetLength(1));
        Debug.Log("from x " + from.x);
        Debug.Log("from y " + from.y);
        Debug.Log("to x " + to.x);
        Debug.Log("to y " + to.y);

        List<PathFind.Point> path = PathFind.Pathfinding.FindPath(grid, from, to);

        Debug.LogWarning (path.Count);

        if (path.Count > 0) {
                Direction rand = getDirection(from, path[0]);
                Vector3 Point = Vector2.zero;

                if (rand == Direction.RIGHT)
                {
                        gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);
                        Point = new Vector3(transform.position.x +  roamingDistance, transform.position.y, 0);
                }

                if (rand == Direction.UP)
                {
// gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);
                        Point = new Vector3(transform.position.x, transform.position.y+ roamingDistance, 0);
                }

                if (rand == Direction.LEFT)
                {
                        gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);
                        Point = new Vector3(transform.position.x - roamingDistance, transform.position.y, 0);
                }

                if (rand == Direction.DOWN)
                {
// gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);
                        Point = new Vector3(transform.position.x, transform.position.y - roamingDistance, 0);
                }

                if (rand == Direction.UP_RIGHT)
                {
                        gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);
                        Point = new Vector3(transform.position.x + roamingDistance, transform.position.y + roamingDistance, 0);
                }

                if (rand == Direction.UP_LEFT)
                {
                        gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);
                        Point = new Vector3(transform.position.x - roamingDistance, transform.position.y + roamingDistance, 0);
                }

                if (rand == Direction.DOWN_LEFT)
                {
                        gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);
                        Point = new Vector3(transform.position.x - roamingDistance, transform.position.y - roamingDistance, 0);
                }

                if (rand == Direction.DOWN_RIGHT)
                {
                        gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);
                        Point = new Vector3(transform.position.x + roamingDistance, transform.position.y - roamingDistance, 0);
                }

                Vector3 AnimalStartPosition = gameObject.transform.position;
                Vector3 dir = (Point - AnimalStartPosition).normalized;
                float distanceToPointFromStart = Vector2.Distance(Point, AnimalStartPosition);
                float distanceToPoint = Vector2.Distance(Point, gameObject.transform.position);

                while (distanceToPoint >= 0.01)
                {

                        distanceToPoint = Vector2.Distance(Point, gameObject.transform.position);
                        gameObject.transform.position += dir / 100 * speed;
//Debug.Log(distanceToPoint);

                        yield return null;
                }
                isRoaming = false;
        }
}

public IEnumerator randomizeRoaming(int percent, int seconds)
{
        Debug.Log(alive);

        while (alive == true)
        {
                yield return new WaitForSeconds(seconds);

                if (Random.Range(0, 100) < percent && isRoaming == false)
                {

                        StartCoroutine(roaming());
                        isRoaming = true;
                }

        }

}

public bool[,] getCollisionMapTurtle(TileTypes[,] tileMap)
{
        bool[,] collisionMap = new bool[tileMap.GetLength(0), tileMap.GetLength(1)];

        for (int y = 0; y < tileMap.GetLength(0); y++) {
                for (int x = 0; x< tileMap.GetLength(1); x++) {
                        switch (tileMap[y,x]) {
                        case (TileTypes.DeepA):
                        case (TileTypes.DeepB_0):
                        case (TileTypes.DeepB_90):
                        case (TileTypes.DeepB_180):
                        case (TileTypes.DeepB_270):
                        case (TileTypes.Thorntendrils):
                        case (TileTypes.Stonewall):
                                collisionMap [y, x] = false;
                                break;
                        default:
                                collisionMap [y, x] = true;
                                break;
                        }
                }
        }

        return collisionMap;
}

public bool[,] getCollisionMap(TileTypes[,] tileMap)
{
        bool[,] collisionMap = new bool[tileMap.GetLength(0), tileMap.GetLength(1)];

        for (int x = 0; x < tileMap.GetLength(0); x++) {
                for (int y = 0; y< tileMap.GetLength(1); y++) {
                        switch (tileMap[x,y]) {
                        case (TileTypes.DeepA):
                        case (TileTypes.DeepB_0):
                        case (TileTypes.DeepB_90):
                        case (TileTypes.DeepB_180):
                        case (TileTypes.DeepB_270):
                        case (TileTypes.Thorntendrils):
                        case (TileTypes.Water):
                                collisionMap [x, y] = false;
                                break;
                        default:
                                collisionMap [x, y] = true;
                                break;
                        }
                }
        }

        foreach (var tile in tileFactory.thorntendrils) {
                collisionMap[Mathf.RoundToInt (tile.transform.position.x),Mathf.RoundToInt (tile.transform.position.y) * -1] = false;
        }

        foreach (var tile in tileFactory.water) {
                collisionMap[Mathf.RoundToInt (tile.transform.position.x),Mathf.RoundToInt (tile.transform.position.y) * -1] = false;
        }

        return collisionMap;
}
}
