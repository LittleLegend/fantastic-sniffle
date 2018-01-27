using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {


public TileTypes currentMode;
public Tiles currentTile;
public TileFactory TileFactory;


    // Use this for initialization
    void Start () {
        currentMode = TileTypes.Stonewall;
        currentTile =null;
    }

// Update is called once per frame
void Update () {

}





public void SetModeStonewall()
{if (currentMode!= TileTypes.Stonewall)
        {
            currentMode = TileTypes.Stonewall;
        }
}

public void SetModeThorntendrils()
{
        if (currentMode != TileTypes.Thorntendrils)
        {
            currentMode = TileTypes.Thorntendrils;
        }
}

public void SetModeWater()
{
        if (currentMode != TileTypes.Water)
        {
            currentMode = TileTypes.Water;
            
        }
}

}
