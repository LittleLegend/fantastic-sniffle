﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {
    public bool isRoaming=false;
    public int roamingDistance;
    public int speed;
    public bool alive;

	void Start () {
        alive = true;
        StartCoroutine(randomizeRoaming(50,1));
	}
	
	
	void Update () {
		
	}

    public IEnumerator roaming()
    {
        
        int rand = Random.Range(0, 7);
        
        Vector3 Point = Vector2.zero;

        Debug.Log(rand);
        if (rand == 0)
        {
            

            gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);
           
            Point = new Vector3(transform.position.x +  roamingDistance, transform.position.y, 0);
        }

        if (rand == 1)
        {
          

            gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);

            Point = new Vector3(transform.position.x  , transform.position.y+ roamingDistance , 0);
        }

        if (rand == 2)
        {
            

            gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);

            Point = new Vector3(transform.position.x - roamingDistance , transform.position.y, 0);
        }

        if (rand == 3)
        {


            gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);

            Point = new Vector3(transform.position.x , transform.position.y - roamingDistance , 0);
        }

        if (rand == 4)
        {
            
            gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);

            Point = new Vector3(transform.position.x + roamingDistance, transform.position.y + roamingDistance, 0);
        }

        if (rand == 5)
        {

            gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);

            Point = new Vector3(transform.position.x - roamingDistance, transform.position.y + roamingDistance, 0);
        }

        if (rand == 6)
        {
            

            gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);

            Point = new Vector3(transform.position.x - roamingDistance, transform.position.y - roamingDistance, 0);
        }

        if (rand == 7)
        {

            gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);

            Point = new Vector3(transform.position.x + roamingDistance, transform.position.y - roamingDistance, 0);
        }



        Vector3 AnimalStartPosition = gameObject.transform.position;
        Vector3 dir = (Point - AnimalStartPosition).normalized;
        float distanceToPointFromStart = Vector2.Distance(Point, AnimalStartPosition);
        float distanceToPoint = Vector2.Distance(Point, gameObject.transform.position);
        
        while (distanceToPoint >= 0.01)
        {

            distanceToPoint = Vector2.Distance(Point, gameObject.transform.position);
            gameObject.transform.position += dir / 100 * speed;
            //Debug.Log(distanceToPoint);

            yield return null;
        }
        isRoaming = false;
        
    }

    public IEnumerator randomizeRoaming(int percent, int seconds)
    {
        Debug.Log(alive);

        while (alive == true)
        {
            yield return new WaitForSeconds(seconds);
            
            if (Random.Range(0, 100) < percent && isRoaming == false)
            {
                
                StartCoroutine(roaming());
                isRoaming = true;
            }
            
        }

    }
}
