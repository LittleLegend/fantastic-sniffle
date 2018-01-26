using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TileTypes {Background, Stonewall, Water, Thorntendrils, Deep1, Deep2, Deep3};

public class TileFactory : MonoBehaviour {


    public int tilecount;
    float width;
    float length;
    public GameObject Tile;
    public List<GameObject> Tiles;
	TileTypes[,] tilemap = new TileTypes[,] { {TileTypes.Background , TileTypes.Stonewall } , 
		{ TileTypes.Stonewall, TileTypes.Background } };

	// Use this for initialization
	void Start () {
        StartCoroutine(createsTiles());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator createsTiles()
    {
        for(int i=0; i<tilemap.Rank;i++)
        {
            for(int j=0; j<tilemap.GetLength(i); j++)
            {

				if (tilemap[i,j] == TileTypes.Background)
                {
                    Debug.Log("create " + tilemap[i,j]+ " at " + i + ", " + j);
                    Instantiate(Tile, new Vector2(-i,-j), Quaternion.identity);
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
