using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {


public TileTypes currentMode;
public Tiles currentTile;


// Use this for initialization
void Start () {
        currentMode = TileTypes.Stonewall;
}

// Update is called once per frame
void Update () {

}





public void SetModeStonewall()
{
								currentMode = TileTypes.Stonewall;
}

public void SetModeThorntendrils()
{
								currentMode = TileTypes.Thorntendrils;
}

public void SetModeDeep()
{
								currentMode = TileTypes.DeepA;
}

public void SetModeWater()
{
								currentMode = TileTypes.Water;
}

}
