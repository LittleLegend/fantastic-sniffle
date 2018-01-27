using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileTypes {Background,
                       Stonewall, Water, Thorntendrils,
                       DeepA_0, DeepA_90,
                       DeepB_0, DeepB_90, DeepB_180, DeepB_270,
                       DeepC_0, DeepC_90, DeepC_180, DeepC_270 };

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

private GameObject AddedTile;



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
                                thorntendrils.Add(AddedTile);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.Thorntendrils;
                        break;
                        case (TileTypes.DeepA_0):
                                Debug.Log ("create Background at " + x + ", " + y);
                                AddedTile = Instantiate(DeepA, new Vector2(x, -y), Quaternion.identity);
                                deep.Add(AddedTile);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA_0;
                                break;
                        case (TileTypes.DeepA_90):
                                Debug.Log ("create Background at " + x + ", " + y);
                                AddedTile = Instantiate(DeepA, new Vector2(x, -y), Quaternion.AngleAxis(90, Vector3.forward));
                                deep.Add(AddedTile);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA_0;
                                break;
                        case (TileTypes.DeepB_0):
                                Debug.Log ("create Background at " + x + ", " + y);
                                AddedTile= Instantiate(DeepB, new Vector2(x, -y), Quaternion.AngleAxis(0, Vector3.forward));
                                deep.Add(AddedTile);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA_0;
                                break;
                        case (TileTypes.DeepB_90):
                                Debug.Log ("create Background at " + x + ", " + y);
                                AddedTile = Instantiate(DeepB, new Vector2(x, -y), Quaternion.AngleAxis(270, Vector3.forward));
                                deep.Add(AddedTile);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA_0;
                                break;
                        case (TileTypes.DeepB_180):
                                Debug.Log ("create Background at " + x + ", " + y);
                                AddedTile = Instantiate(DeepB, new Vector2(x, -y), Quaternion.AngleAxis(180, Vector3.forward));
                                deep.Add(AddedTile);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA_0;
                                break;
                        case (TileTypes.DeepB_270):
                                Debug.Log ("create Background at " + x + ", " + y);
                                AddedTile = Instantiate(DeepB, new Vector2(x, -y), Quaternion.AngleAxis(90, Vector3.forward));
                                deep.Add(AddedTile);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA_0;
                                break;
                        case (TileTypes.DeepC_0):
                                Debug.Log ("create Background at " + x + ", " + y);
                                AddedTile = Instantiate(DeepC, new Vector2(x, -y), Quaternion.identity);
                                deep.Add(AddedTile);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA_0;
                                break;
                        case (TileTypes.DeepC_90):
                                Debug.Log ("create Background at " + x + ", " + y);
                                AddedTile = Instantiate(DeepC, new Vector2(x, -y), Quaternion.AngleAxis(90, Vector3.forward));
                                deep.Add(AddedTile);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA_0;
                                break;
                        case (TileTypes.DeepC_180):
                                Debug.Log ("create Background at " + x + ", " + y);
                                AddedTile = Instantiate(DeepC, new Vector2(x, -y), Quaternion.AngleAxis(180, Vector3.forward));
                                deep.Add(AddedTile);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA_0;
                                break;
                        case (TileTypes.DeepC_270):
                                Debug.Log ("create Background at " + x + ", " + y);
                                AddedTile = Instantiate(DeepC, new Vector2(x, -y), Quaternion.AngleAxis(270, Vector3.forward));
                                deep.Add(AddedTile);
                                AddedTile.GetComponent<Tiles>().myType = TileTypes.DeepA_0;
                                break;
                        default:
                                break;
                        }
                }

        }
}
}
