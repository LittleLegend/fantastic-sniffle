using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileTypes {Background,
                       Stonewall, Water, Thorntendrils,
                       DeepA,
                       DeepB_0, DeepB_90, DeepB_180, DeepB_270,
                       DeepC_0, DeepC_180 };

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

public List<GameObject> stonewalls;
public List<GameObject> water;
public List<GameObject> deep;
public List<GameObject> thorntendrils;

private   GameObject AddedTile;



    // Use this for initialization
    void Start () {
        createsTiles();
}

// Update is called once per frame
void Update () {

}

public void addTile(TileTypes tile, Vector2 position) {

        
        

        

        switch (tile)
        {   
            case TileTypes.Stonewall:
                 AddedTile = Instantiate(Stonewall, position, Quaternion.identity);
                stonewalls.Add(AddedTile);
                
                AddedTile.GetComponent<Tiles>().myType = TileTypes.Stonewall;


                break;

            case TileTypes.Water:
                 AddedTile = Instantiate(Water, position, Quaternion.identity);
                water.Add(AddedTile);
                
                AddedTile.GetComponent<Tiles>().myType = TileTypes.Water;

                break;

            case TileTypes.Thorntendrils:
                 AddedTile = Instantiate(Thorntendrils, position, Quaternion.identity);
                thorntendrils.Add(AddedTile);
                
                AddedTile.GetComponent<Tiles>().myType = TileTypes.Thorntendrils;

                break;

            case TileTypes.DeepA:
                 AddedTile = Instantiate(DeepA, position, Quaternion.identity);
                deep.Add(AddedTile);
                
                AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA;
                break;


        }
        
}

    public void destroyTile(GameObject ClickedTile, TileTypes type)
    {
        switch (type)
        {
            case TileTypes.Stonewall:
                stonewalls.Remove(ClickedTile);

                break;

            case TileTypes.Water:
                water.Remove(ClickedTile);

                break;

            case TileTypes.Thorntendrils:
                thorntendrils.Remove(ClickedTile);

                break;

            case TileTypes.DeepA:
                deep.Remove(ClickedTile);

                break;


        }

        




        Destroy(ClickedTile);
        
    }


    public void createsTiles() {
        int width = Level1.tilemap.GetLength(0);
        int height = Level1.tilemap.GetLength(1);
        

        for (int x=0; x < width; x++)
        {
                for(int y=0; y < height; y++)
                {
                
                switch (Level1.tilemap[x,y]) {
                    
                    
                        case (TileTypes.Background):
                        
                                Debug.Log ("create Background at " + x + ", " + y);
                                GameObject AddedTile=Instantiate (Background, new Vector2 (x, -y), Quaternion.identity);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.Background;
                        break;
                        case (TileTypes.Stonewall):
                                Debug.Log ("create Background at " + x + ", " + y);
                               AddedTile = Instantiate(Stonewall, new Vector2(x, -y), Quaternion.identity);
                               stonewalls.Add(AddedTile);
                               AddedTile.GetComponent<Tiles>().myType = TileTypes.Stonewall;

                        break;
                        case (TileTypes.Water):
                                Debug.Log ("create Background at " + x + ", " + y);
                                AddedTile=Instantiate (Water, new Vector2 (x, -y), Quaternion.identity);
                                water.Add(AddedTile);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.Water;
                        break;
                        case (TileTypes.Thorntendrils):
                                Debug.Log ("create Background at " + x + ", " + y);
                        AddedTile = Instantiate(Thorntendrils, new Vector2(x, -y), Quaternion.identity);
                        thorntendrils.Add(Instantiate(Thorntendrils, new Vector2(x, -y), Quaternion.identity));
                        AddedTile.GetComponent<Tiles>().myType = TileTypes.Thorntendrils;
                        break;
                        case (TileTypes.DeepA):
                                Debug.Log ("create Background at " + x + ", " + y);
                        AddedTile = Instantiate(DeepA, new Vector2(x, -y), Quaternion.identity);
                                deep.Add(Instantiate (DeepA, new Vector2 (x, -y), Quaternion.identity));
                        AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA;
                        break;
                        case (TileTypes.DeepB_0):
                                Debug.Log ("create Background at " + x + ", " + y);
                        AddedTile= Instantiate(DeepB, new Vector2(x, -y), Quaternion.AngleAxis(0, Vector3.forward));
                                deep.Add(Instantiate (DeepB, new Vector2 (x, -y), Quaternion.AngleAxis(0, Vector3.forward)));
                        AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA;
                        break;
                        case (TileTypes.DeepB_90):
                                Debug.Log ("create Background at " + x + ", " + y);
                        AddedTile = Instantiate(DeepB, new Vector2(x, -y), Quaternion.AngleAxis(270, Vector3.forward));
                                deep.Add(Instantiate (DeepB, new Vector2 (x, -y), Quaternion.AngleAxis(270, Vector3.forward)));
                        AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA;
                        break;
                        case (TileTypes.DeepB_180):
                                Debug.Log ("create Background at " + x + ", " + y);
                        AddedTile = Instantiate(DeepB, new Vector2(x, -y), Quaternion.AngleAxis(180, Vector3.forward));
                                deep.Add(Instantiate (DeepB, new Vector2 (x, -y), Quaternion.AngleAxis(180, Vector3.forward)));
                        AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA;
                        break;
                        case (TileTypes.DeepB_270):
                                Debug.Log ("create Background at " + x + ", " + y);
                        AddedTile = Instantiate(DeepB, new Vector2(x, -y), Quaternion.AngleAxis(90, Vector3.forward));
                                deep.Add(Instantiate (DeepB, new Vector2 (x, -y), Quaternion.AngleAxis(90, Vector3.forward)));
                        AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA;
                        break;
                        case (TileTypes.DeepC_0):
                                Debug.Log ("create Background at " + x + ", " + y);
                        AddedTile = Instantiate(DeepB, new Vector2(x, -y), Quaternion.identity);
                                deep.Add(Instantiate (DeepB, new Vector2 (x, -y), Quaternion.identity));
                        AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA;
                        break;
                        case (TileTypes.DeepC_180):
                                Debug.Log ("create Background at " + x + ", " + y);
                        AddedTile = Instantiate(DeepC, new Vector2(x, -y), Quaternion.AngleAxis(180, Vector3.forward));
                                deep.Add(Instantiate (DeepC, new Vector2 (x, -y), Quaternion.AngleAxis(180, Vector3.forward)));
                        AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA;
                        break;
                        default:
                                break;
                        }
                }

        }

        // create the tiles map
        // bool[,] collisionMap = new bool[3,3] {
        //         { true, false, true },
        //         { true, false, true },
        //         { true, true, true }
        // };

        // bool[,] collisionMap = getCollisionMapCat(Level1.tilemap);
        //
        // for (int x = 0; x < collisionMap.GetLength(0); x++) {
        //         for (int y = 0; y< collisionMap.GetLength(1); y++) {
        //                 Debug.Log(x+", "+y+": "+collisionMap[x,y]);
        //         }
        // }
        //
        // // set values here....
        // // every float in the array represent the cost of passing the tile at that position.
        // // use 0.0f for blocking tiles.
        //
        // // create a grid
        // int width = collisionMap.GetLength(0);
        // int height = collisionMap.GetLength (1);
        // PathFind.Grid grid = new PathFind.Grid(width, height, collisionMap);
        //
        // // create source and target points
        // PathFind.Point _from = new PathFind.Point(0, 6);
        // PathFind.Point _to = new PathFind.Point(2, 9);
        //
        // // get path
        // // path will either be a list of Points (x, y), or an empty list if no path is found.
        // List<PathFind.Point> path = PathFind.Pathfinding.FindPath(grid, _from, _to);
        //
        // foreach (var point in path) {
        //         Debug.Log (point.x + ", "+ point.y);
        // }
}

public bool[,] getCollisionMapCat(TileTypes[,] tileMap)
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
                        case (TileTypes.Stonewall):
                        case (TileTypes.Water):
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


public bool[,] getCollisionMapBird(TileTypes[,] tileMap)
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

        return collisionMap;
}

}
