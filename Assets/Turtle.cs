using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {
public bool isRoaming=false;
public int roamingDistance;
public int speed;
public bool alive;
public TileFactory tileFactory;
public AnimalFactory animalFactory;

void Start () {
        alive = true;
        tileFactory = GameObject.Find ("TileFactory").GetComponent<TileFactory>();
        animalFactory = GameObject.Find ("AnimalFactory").GetComponent<AnimalFactory>();
        StartCoroutine(randomizeRoaming());
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
                return Direction.DOWN;
        } else if (down && left) {
                return Direction.DOWN_LEFT;
        } else if (down && right) {
                return Direction.DOWN_RIGHT;
        } else if (up && !left && !right) {
                return Direction.UP;
        } else if (up && left) {
                return Direction.UP_LEFT;
        } else if (up && right) {
                return Direction.UP_RIGHT;
        } else if (right) {
                return Direction.RIGHT;
        } else {
                return Direction.LEFT;
        }
}

public IEnumerator roaming()
{
        bool[,] collisionMap = getCollisionMap (Level1.tilemap);
        Vector2 preyPosition = findClosestPrey();

        int width = collisionMap.GetLength(0);
        int height = collisionMap.GetLength (1);
        PathFind.Grid grid = new PathFind.Grid(width, height, collisionMap);
        PathFind.Point from = new PathFind.Point(Mathf.RoundToInt(gameObject.transform.position.x),
                                                 Mathf.RoundToInt(gameObject.transform.position.y) * -1);
        PathFind.Point to = new PathFind.Point(Mathf.RoundToInt(preyPosition.x),
                                               Mathf.RoundToInt(preyPosition.y) * -1);

        List<PathFind.Point> path = PathFind.Pathfinding.FindPath(grid, from, to);


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
                        Point = new Vector3(transform.position.x, transform.position.y+ roamingDistance, 0);
                }

                if (rand == Direction.LEFT)
                {
                        gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);
                        Point = new Vector3(transform.position.x - roamingDistance, transform.position.y, 0);
                }

                if (rand == Direction.DOWN)
                {
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
                float distanceToPoint = Vector2.Distance(Point, gameObject.transform.position);

                while (distanceToPoint >= 0.01)
                {
                        distanceToPoint = Vector2.Distance(Point, gameObject.transform.position);
                        gameObject.transform.position += dir / 100 * speed;

                        yield return null;
                }
                isRoaming = false;
        }
}

public IEnumerator randomizeRoaming()
{
        while (alive == true)
        {
                yield return roaming();
        }
}

public Vector2 findClosestPrey() {
        Vector2 preyPosition = transform.position;
        float distance = 100000;
        float myX = transform.position.x;
        float myY = transform.position.y;

        foreach (var cat in animalFactory.Cats) {
                float theirX = cat.transform.position.x;
                float theirY = cat.transform.position.y;

                float newDistance = Mathf.Abs(myX - theirX) + Mathf.Abs(myY - theirY);

                if (newDistance < distance) {
                        distance = newDistance;
                        preyPosition = cat.transform.position;
                }

        }

        return preyPosition;
}


public bool[,] getCollisionMap(TileTypes[,] tileMap)
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

        foreach (var tile in tileFactory.thorntendrils) {
                collisionMap[Mathf.RoundToInt (tile.transform.position.x),Mathf.RoundToInt (tile.transform.position.y) * -1] = false;
        }

        foreach (var tile in tileFactory.stonewalls) {
                collisionMap[Mathf.RoundToInt (tile.transform.position.x),Mathf.RoundToInt (tile.transform.position.y) * -1] = false;
        }

        return collisionMap;
}
}
