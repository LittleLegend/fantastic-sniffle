using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Values : MonoBehaviour {

    public int stonewallCount;
    public int waterCount;
    public int thorntendrilsCount;
    public int deepCount;
    public TextMeshProUGUI stonewallLabel;
    public TextMeshProUGUI waterLabel;
    public TextMeshProUGUI thorntendrilsLabel;
    public TextMeshProUGUI deepLabel;




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateLabels();

    }

    public void UpdateLabels()
    {
        stonewallLabel.text = stonewallCount.ToString();
        waterLabel.text = waterCount.ToString();
        thorntendrilsLabel.text = thorntendrilsCount.ToString();
        deepLabel.text = deepCount.ToString();


    }
}
