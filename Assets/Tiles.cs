using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{

    public InputController InputController;
    public TileFactory tileFactory;
    public Values Values;
    public TileTypes myType;



    // Use this for initialization
    void Start()
    {
        Values = GameObject.Find("Values").GetComponent<Values>();
        InputController = GameObject.Find("Map").GetComponent<InputController>();
        tileFactory = GameObject.Find("TileFactory").GetComponent<TileFactory>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
        public void OnMouseOver()
    {
        InputController.currentTile = gameObject.GetComponent<Tiles>();
        if (Input.GetMouseButton(0) && InputController.currentMode != InputController.currentTile.myType )
        {
            TileCount();
            

        }
    }


    public void DestroyAdd()
    {
        tileFactory.addTile(InputController.GetComponent<InputController>().currentMode, gameObject.transform.position);
        tileFactory.destroyTile(gameObject, InputController.GetComponent<InputController>().currentMode);
    }

    public void TileCount()
    {
        TileTypes type= InputController.GetComponent<InputController>().currentMode;

        switch (type)
        {
            case TileTypes.Stonewall:
                if (Values.stonewallCount > 0)
                {
                    Values.stonewallCount -= 1;
                    DestroyAdd();
                }

                break;

            case TileTypes.Water:
                if (Values.waterCount > 0)
                {
                    Values.waterCount -= 1;
                    DestroyAdd();
                }
                break;

            case TileTypes.Thorntendrils:
                if (Values.thorntendrilsCount > 0)
                {
                    Values.thorntendrilsCount -= 1;
                    DestroyAdd();
                }
                break;

            case TileTypes.DeepA_0:
                if (Values.deepCount > 0)
                {
                    Values.deepCount -= 1;
                    DestroyAdd();
                }
                break;


        }


    }


    }
