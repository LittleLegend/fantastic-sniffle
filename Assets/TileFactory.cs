using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TileTypes {Background, Stonewall, Water, Thorntendrils, Deep1, Deep2, Deep3};

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

        yield return null;
}

public IEnumerator addTiles()
{


        yield return null;
}

}
