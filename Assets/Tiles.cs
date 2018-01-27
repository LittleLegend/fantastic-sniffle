using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{

    public InputController InputController;
    public TileFactory tileFactory;
    public  TileTypes myType;


    // Use this for initialization
    void Start()
    {
        InputController = gameObject.GetComponent<InputController>();
        tileFactory = GameObject.Find("TileFactory").GetComponent<TileFactory>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
        public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            tileFactory.addTile(TileTypes.Stonewall, gameObject.transform.position);
            tileFactory.destroyTile(gameObject);
        }
    }


 
}
