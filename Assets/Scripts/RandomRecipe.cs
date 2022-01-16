using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRecipe : MonoBehaviour
{
    int random;
    int RecipeNumber = 0;
    float counter;
    public float timeRemaining = 100;
    public Transform Kaffee;
    public Transform Pizza;
    public List<Transform> allRecipes;
    public Transform UI;

    void Start()
    {
        giveRandom();
        counter = timeRemaining;
    }

    void Update()
    {
        // Makes a Timer
        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
        }

        // randomizer for recipes
        if(timeRemaining <= counter-10) {
            counter -= 10;
            giveRandom();

            Debug.Log(random + " " + timeRemaining);

            switch(random){
                case 1: drawCoffee(); break;
                case 2: drawPizza(); break;
            }
            RecipeNumber++;
        }
    }

    void giveRandom(){
        random = Random.Range(1, 100);
        if(random<50) {random = 1;} else {random = 2;}
    }

//TODO: REFACTOR THIS LILO!!
    void drawCoffee(){
        Transform newCoffee = Instantiate (Kaffee, UI);     
        newCoffee.transform.position = newCoffee.position + new Vector3(RecipeNumber*180,0,0);
        allRecipes.Add(newCoffee);
    }

    void drawPizza(){
        Transform newPizza = Instantiate (Pizza, UI);
        newPizza.transform.position = newPizza.position + new Vector3(RecipeNumber*180,0,0);
        allRecipes.Add(newPizza);
    }

    public void destroyCoffeeRecipe() {
        var checker = false;
        foreach(Transform item in allRecipes){
            if(item.CompareTag("CoffeeRecipe") && checker==false){
                Destroy(item.gameObject);
                checker = true;
            }
            if(checker == true) item.transform.position = item.position - new Vector3(180,0,0); 
        }
        RecipeNumber--;
    }

    public void destroyPizzaRecipe() {
        var checker = false;
        foreach(Transform item in allRecipes){
            if(item.CompareTag("PizzaRecipe") && checker==false){
                Destroy(item.gameObject);
                checker = true;
            }
            if(checker == true) item.transform.position = item.position - new Vector3(180,0,0);
        }
        RecipeNumber--;
    }

}
