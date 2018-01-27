using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{

    public InputController InputController;



    // Use this for initialization
    void Start()
    {
        InputController = gameObject.GetComponent<InputController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.LogWarning("Hey");
        }
    }

    public void Clicked()
    {
        Debug.Log("Hi");
        InputController.currentTile = gameObject.GetComponent<Tiles>();

    }
}
