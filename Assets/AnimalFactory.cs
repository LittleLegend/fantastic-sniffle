using System.Collections;
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

// Use this for initialization
void Start () {
								StartCoroutine(createRandomAnimals());
}

// Update is called once per frame
void Update () {

}

public void addAnimal(AnimalType animal, Vector2 position) {

								switch (animal) {
								case (AnimalType.Cat):
																Cats.Add(Instantiate (Cat, position, Quaternion.identity));
																break;
								case (AnimalType.Bird):
																Birds.Add(Instantiate (Bird, position, Quaternion.identity));
																break;
								case (AnimalType.Turtle):
																Turtles.Add(Instantiate (Turtle, position, Quaternion.identity));
																break;

								default:
																break;
								}
}

public IEnumerator createRandomAnimals () {
								AnimalType rand = (AnimalType) Random.Range(0, 2);
								// Vector2 position  = new Vector2((int) Random.Range())

								while (true) {
																yield return new WaitForSeconds(5);
																addAnimal(rand, new Vector2(0,0));
								}
}


}
