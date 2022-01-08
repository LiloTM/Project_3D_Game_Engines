using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRecipe : MonoBehaviour
{
    int random;
    float counter;
    public float timeRemaining = 100;

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
        }
    }

    void giveRandom(){
        random = Random.Range(1, 100);
        if(random<50) {random = 1;} else {random = 2;}
    }

    void drawCoffee(){

    }

    void drawPizza(){
        
    }

}
