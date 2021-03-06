﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turtle : MonoBehaviour {
public bool isRoaming=false;
public int roamingDistance;
public int speed;
public bool alive;
public TileFactory tileFactory;
public AnimalFactory animalFactory;
public bool ishunting = false;
public bool hashunted = false;
public StateManager StateManager;

void Start () {
        alive = true;
        tileFactory = GameObject.Find ("TileFactory").GetComponent<TileFactory>();
        StateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
        animalFactory = GameObject.Find ("AnimalFactory").GetComponent<AnimalFactory>();
        StartCoroutine(randomizeRoaming());
}

void Update () {
}

public enum Direction {UP, DOWN,
                       RIGHT, LEFT,
                       UP_RIGHT, UP_LEFT,
                       DOWN_RIGHT, DOWN_LEFT};

public Direction getDirection(Vector2 from, Vector2 to) {
        Vector2 roundedFrom = new Vector2(Mathf.RoundToInt(from.x), Mathf.RoundToInt(from.y));
        Vector2 roundedTo = new Vector2(Mathf.RoundToInt(to.x), Mathf.RoundToInt(to.y));

        bool right = roundedFrom.x < roundedTo.x;
        bool left = roundedFrom.x > roundedTo.x;
        bool down = roundedFrom.y > roundedTo.y;
        bool up = roundedFrom.y < roundedTo.y;

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

public IEnumerator moveTo(Vector2 to)
{
        Debug.LogWarning ("start corouting");
        Direction rand = getDirection(gameObject.transform.position, to);
        Vector3 Point = Vector2.zero;

        gameObject.GetComponent<Animator>().SetBool("up", false);
        gameObject.GetComponent<Animator>().SetBool("down", false);
        if (rand == Direction.RIGHT)
        {
                gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);
                Point = new Vector3(transform.position.x +  roamingDistance, transform.position.y, 0);
        }

        if (rand == Direction.UP)
        {
                Point = new Vector3(transform.position.x, transform.position.y+ roamingDistance, 0);
                gameObject.GetComponent<Animator>().SetBool("up", true);
        }

        if (rand == Direction.LEFT)
        {
                gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);
                Point = new Vector3(transform.position.x - roamingDistance, transform.position.y, 0);
        }

        if (rand == Direction.DOWN)
        {
                Point = new Vector3(transform.position.x, transform.position.y - roamingDistance, 0);
                gameObject.GetComponent<Animator>().SetBool("down", true);
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

        while (alive==true) {
                float distanceToPoint = Vector2.Distance(Point, gameObject.transform.position);

                if (distanceToPoint >= 0.01)
                {
                        // keep walking
                        gameObject.transform.position += dir / 100 * speed;
                        yield return null;
                } else {
                        // stop working
                        Debug.LogWarning ("break corouting");
                        break;
                }
        }
        Debug.LogWarning ("leave corouting");

}

public IEnumerator randomizeRoaming()
{
        while (alive == true)
        {
                bool[,] collisionMap = getCollisionMap (Level1.tilemap);
                Vector2 preyPosition = findClosestPrey();

                int width = collisionMap.GetLength(0);
                int height = collisionMap.GetLength (1);
                PathFind.Grid grid = new PathFind.Grid(width, height, collisionMap);
                PathFind.Point from = PathFind.Point.fromVector (transform.position);
                PathFind.Point to = PathFind.Point.fromVector (preyPosition);
                List<PathFind.Point> path = PathFind.Pathfinding.FindPath(grid, from, to);

                if (path.Count > 0) {
                        ishunting = true;
                        PathFind.Point next = path[0];
                        yield return moveTo(next.toVector());

                }
                ishunting = false;
                yield return null;
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
                        case (TileTypes.DeepA_0):
                        case (TileTypes.DeepA_90):
                        case (TileTypes.DeepB_0):
                        case (TileTypes.DeepB_90):
                        case (TileTypes.DeepB_180):
                        case (TileTypes.DeepB_270):
                        case (TileTypes.DeepC_0):
                        case (TileTypes.DeepC_90):
                        case (TileTypes.DeepC_180):
                        case (TileTypes.DeepC_270):
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

public void OnTriggerEnter2D(Collider2D col)
{
        if (col.gameObject.tag == "Tile")
        {
                col.gameObject.GetComponent<Tiles>().hasAnimal = true;



        }

        if (col.gameObject.tag == "Cat")
        {

            if (!StateManager.death.isPlaying)
            {
                SceneManager.LoadScene(4);
            }
            StateManager.theme.Stop();

        }

}
public void OnTriggerExit2D(Collider2D col)
{


        if (col.gameObject.tag == "Tile")
        {
                col.gameObject.GetComponent<Tiles>().hasAnimal = false;


        }
}
}
