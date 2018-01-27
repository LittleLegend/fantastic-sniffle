using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {
public bool isRoaming=false;
public int roamingDistance;
public int speed;
public bool alive;

void Start () {
        alive = true;
        StartCoroutine(randomizeRoaming(50,1));
}

void Update () {
}

// public enum Direction {Up,
//                        Down, Right, Left,
//                        DeepA,
//                        DeepB_0, DeepB_90, DeepB_180, DeepB_270,
//                        DeepC_0, DeepC_180 };

public IEnumerator roaming()
{

        int rand = Random.Range(0, 7);

        Vector3 Point = Vector2.zero;

        Debug.Log(rand);
        if (rand == 0)
        {


                gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);

                Point = new Vector3(transform.position.x +  roamingDistance, transform.position.y, 0);
        }

        if (rand == 1)
        {


                gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);

                Point = new Vector3(transform.position.x, transform.position.y+ roamingDistance, 0);
        }

        if (rand == 2)
        {


                gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);

                Point = new Vector3(transform.position.x - roamingDistance, transform.position.y, 0);
        }

        if (rand == 3)
        {


                gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);

                Point = new Vector3(transform.position.x, transform.position.y - roamingDistance, 0);
        }

        if (rand == 4)
        {

                gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);

                Point = new Vector3(transform.position.x + roamingDistance, transform.position.y + roamingDistance, 0);
        }

        if (rand == 5)
        {

                gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);

                Point = new Vector3(transform.position.x - roamingDistance, transform.position.y + roamingDistance, 0);
        }

        if (rand == 6)
        {


                gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);

                Point = new Vector3(transform.position.x - roamingDistance, transform.position.y - roamingDistance, 0);
        }

        if (rand == 7)
        {

                gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);

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

        for (int x = 0; x < tileMap.GetLength(0); x++) {
                for (int y = 0; y< tileMap.GetLength(1); y++) {
                        switch (tileMap[x,y]) {
                        case (TileTypes.DeepA):
                        case (TileTypes.DeepB_0):
                        case (TileTypes.DeepB_90):
                        case (TileTypes.DeepB_180):
                        case (TileTypes.DeepB_270):
                        case (TileTypes.Thorntendrils):
                        case (TileTypes.Stonewall):
                                collisionMap [x, y] = false;
                                break;
                        default:
                                collisionMap [x, y] = true;
                                break;
                        }
                }
        }

        return collisionMap;
}
}
