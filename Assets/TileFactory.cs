using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TileTypes {Background, Stonewall, Water, Thorntendrils, Deep1, Deep1_180, Deep2, Deep3};

public class TileFactory : MonoBehaviour {


public int tilecount;
float width;
float length;
public GameObject Background;
public GameObject Stonewall;
public GameObject Water;
public GameObject Thorntendrils;
public GameObject DeepA;
public GameObject DeepB;
public GameObject DeepC;
    
TileTypes[,] tilemap = new TileTypes[,] {
        {TileTypes.Background, TileTypes.Background , TileTypes.Background },
        { TileTypes.Water, TileTypes.Background, TileTypes.Water },
        { TileTypes.Background, TileTypes.Background, TileTypes.Background }
};

// Use this for initialization
void Start () {
        StartCoroutine(createsTiles());
}

// Update is called once per frame
void Update () {

}

public IEnumerator createsTiles()
{
        for(int i=0; i<tilemap.GetLength(0); i++)
        {
                for(int j=0; j<tilemap.GetLength(1); j++)
                {
                        switch (tilemap[i,j]) {
                        case (TileTypes.Background):
                                Debug.Log ("create Background at " + i + ", " + j);
                                Instantiate (Background, new Vector2 (-i, -j), Quaternion.identity);
                                break;
                        case (TileTypes.Stonewall):
                                Debug.Log ("create Background at " + i + ", " + j);
                                Instantiate (Stonewall, new Vector2 (-i, -j), Quaternion.identity);
                                break;
                        case (TileTypes.Water):
                                Debug.Log ("create Background at " + i + ", " + j);
                                Instantiate (Water, new Vector2 (-i, -j), Quaternion.identity);
                                break;
                        case (TileTypes.Thorntendrils):
                                Debug.Log ("create Background at " + i + ", " + j);
                                Instantiate (Thorntendrils, new Vector2 (-i, -j), Quaternion.identity);
                                break;
                        case (TileTypes.Deep1):
                                Debug.Log ("create Background at " + i + ", " + j);
                                Instantiate (DeepA, new Vector2 (-i, -j), Quaternion.identity);
                                break;
                        case (TileTypes.Deep1_180):
                                Debug.Log ("create Background at " + i + ", " + j);
                                Instantiate (Tile, new Vector2 (-i, -j), Quaternion.AngleAxis(180, Vector3.up));
                                break;
                        case (TileTypes.Deep2):
                                Debug.Log ("create Background at " + i + ", " + j);
                                Instantiate (DeepB, new Vector2 (-i, -j), Quaternion.identity);
                                break;
                        case (TileTypes.Deep3):
                                Debug.Log ("create Background at " + i + ", " + j);
                                Instantiate (DeepC, new Vector2 (-i, -j), Quaternion.identity);
                                break;
                        default:
                                break;
                        }
                }

        }

        // create the tiles map
        bool[,] tilesmap = new bool[3,3] {
                { true, false, true },
                { true, false, true },
                { true, true, true }
        };
        // set values here....
        // every float in the array represent the cost of passing the tile at that position.
        // use 0.0f for blocking tiles.

        // create a grid
        int width = tilesmap.GetLength(0);
        int height = tilesmap.GetLength (1);
        PathFind.Grid grid = new PathFind.Grid(width, height, tilesmap);

        // create source and target points
        PathFind.Point _from = new PathFind.Point(0, 0);
        PathFind.Point _to = new PathFind.Point(0, 2);

        // get path
        // path will either be a list of Points (x, y), or an empty list if no path is found.
        List<PathFind.Point> path = PathFind.Pathfinding.FindPath(grid, _from, _to);

        foreach (var point in path) {
                Debug.Log (point.x + ", "+ point.y);
        }




        yield return null;
}

public IEnumerator addTiles()
{


        yield return null;
}

}
