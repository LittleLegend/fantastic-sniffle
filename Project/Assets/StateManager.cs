using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour {

    public AudioSource theme;
    public AudioSource death;

    // Use this for initialization
    void Start () {
        theme.Play();
      
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
	}
}
