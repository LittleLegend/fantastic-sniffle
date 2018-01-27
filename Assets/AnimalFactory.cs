﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalType {Cat, Bird, Turtle};

public class AnimalFactory : MonoBehaviour {
public int tilecount;
float width;
float length;
public GameObject Turtle;
public GameObject Cat;
public GameObject Bird;
public List<GameObject> Turtles;
public List<GameObject> Cats;
public List<GameObject> Birds;

// Use this for initializ ation
void Start () {
								StartCoroutine(createRandomAnimals());
}

// Update is called once per frame
void Update () {

}

public void addAnimal(AnimalType animal, Vector2 position) {
								Vector2 gameFieldPosition = new Vector2(position.x, -1 * position.y);

								switch (animal) {
								case (AnimalType.Cat):
																Cats.Add(Instantiate (Cat, gameFieldPosition, Quaternion.identity));
																break;
								case (AnimalType.Bird):
																Birds.Add(Instantiate (Bird, gameFieldPosition, Quaternion.identity));
																break;
								case (AnimalType.Turtle):
																Turtles.Add(Instantiate (Turtle, gameFieldPosition, Quaternion.identity));
																break;

								default:
																break;
								}
}

public IEnumerator createRandomAnimals () {
								while (true) {
																yield return new WaitForSeconds(1);

																AnimalType rand = (AnimalType) Random.Range(0, 3);
																Vector2 position;

																switch (rand) {
																case (AnimalType.Cat):
																								position= new Vector2(4, 3);
																								break;
																case (AnimalType.Turtle):
																								position = new Vector2(0,0);
																								break;
																case (AnimalType.Bird):
																								position = new Vector2(9,0);
																								break;
																default:
																								position = new Vector2(9,0);
																								break;
																}

																addAnimal(rand, position);
								}
}


}
