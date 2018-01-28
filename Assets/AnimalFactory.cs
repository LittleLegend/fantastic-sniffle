using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Level1.reset();
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

                SceneManager.LoadScene(5);
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
                float turtleChance = Random.Range(0, 10) / (Turtles.Count + 1);
                float birdChance = Random.Range(0, 10) / (Birds.Count + 1);
                float catChance = Random.Range(0, 10) / (Cats.Count + 1);
                float wonChance = Mathf.Max (new float[] { turtleChance, birdChance, catChance });

                AnimalType rand = wonChance == turtleChance ? AnimalType.Turtle : wonChance == birdChance ? AnimalType.Bird : AnimalType.Cat;
                SpawnPoint sp;

                switch (rand) {
                case (AnimalType.Cat):
                        sp = Level1.catSpawnPoints[0];
                        break;
                case (AnimalType.Turtle):
                        sp = Level1.turtleSpawnPoints[0];
                        break;
                case (AnimalType.Bird):
                        sp = Level1.birdSpawnPoints[0];
                        break;
                default:
                        sp = Level1.catSpawnPoints[0];
                        break;
                }

                if (sp.unitsToSpawn > 0) {
				sp.unitSpawned ();
                        addAnimal(rand, sp.position);
                }


                yield return new WaitForSeconds(2);
        }
}


}
