using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

public void Restart()
    {

        SceneManager.LoadScene(1);

    }

    public void Exit()
    {

        Application.Quit();

    }

    public void Starting()
    {

        SceneManager.LoadScene(1);

    }

    public void Credits()
    {

        SceneManager.LoadScene(6);

    }

    public void Menue()
    {

        SceneManager.LoadScene(0);

    }

}
