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
public GameObject StateManager;

// Use this for initializ ation
void Start () {
        // createRandomAnimals();
        StartCoroutine(checkWinPerSecond(1));
        StartCoroutine(createRandomAnimals());
}

public IEnumerator checkWinPerSecond(int sek)
    {
        while(true)
        {
            yield return new WaitForSeconds(sek);
           if( checkWinCon())
            {

                Debug.Log("You Won");
            }
        }
        
    }

public bool checkWinCon()
    {
        if(Cats.Count==0 || Birds.Count == 0 || Turtles.Count == 0 )
        { return false; }

        foreach (var cat in Cats)
        {
            if (cat.GetComponent<Cat>().ishunting)
            {
                return false;
            }
        }

        foreach (var turtle in Turtles)
        {
            if (turtle.GetComponent<Turtle>().ishunting)
            {
                return false;
            }
        }

        foreach (var bird in Birds)
        {
            if (bird.GetComponent<Bird>().ishunting)
            {
                return false;
            }
        }

        return true;

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
        // addAnimal(AnimalType.Cat, new Vector2(4, 3));
        // addAnimal(AnimalType.Turtle, new Vector2(0, 0));
        // addAnimal(AnimalType.Bird, new Vector2(9, 0));
        while (true) {
                AnimalType rand = (AnimalType) Random.Range(0, 3);
                Vector2 position;

                switch (rand) {
                case (AnimalType.Cat):
                        position= Level1.CatSpawnPoint;
                        break;
                case (AnimalType.Turtle):
                        position = Level1.TurtleSpawnPoint;
                        break;
                case (AnimalType.Bird):
                        position = Level1.BirdSpawnPoint;
                        break;
                default:
                        position = new Vector2(9,0);
                        break;
                }

                addAnimal(rand, position);

                yield return new WaitForSeconds(5);
        }
}


}
