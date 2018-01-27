using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

public enum Modes { Stonewall, Thorntendrils, Deep, Water };
public Modes currenMode;
public Tiles currentTile;
public TileFactory tileFactory;

// Use this for initialization
void Start () {

}

// Update is called once per frame
void Update () {

}

public void OnMouseClick()
{
								tileFactory.addTile(TileTypes.Stonewall, new Vector2(Mathf.RoundToInt(Input.mousePosition.x), Mathf.RoundToInt(Input.mousePosition.y)));
}



public void SetModeStonewall()
{
								currenMode = Modes.Stonewall;
}

public void SetModeThorntendrils()
{
								currenMode = Modes.Thorntendrils;
}

public void SetModeDeep()
{
								currenMode = Modes.Deep;
}

public void SetModeWater()
{
								currenMode = Modes.Water;
}

}
