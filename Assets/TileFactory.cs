using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory : MonoBehaviour {


    public int tilecount;
    float width;
    float length;
    public GameObject Tile;
    public List<GameObject> Tiles;
    float[,] tilemap = new float[,] { {1 , 0 } , 
                                     { 0, 1 } };

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

                if (tilemap[i,j]==1)
                {
                    Debug.Log("create " + tilemap[i,j]+ " at " + i + ", " + j);
                    Instantiate(Tile, new Vector2(i,j), Quaternion.identity);
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
