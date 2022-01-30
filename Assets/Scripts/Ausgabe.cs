using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ausgabe : MonoBehaviour
{
    public Score score;
    public RandomRecipe randomRecipe;
    public recipeCrafting recipeCrafting;

    private GameObject pizzaRdy;
    private GameObject APizza;
    private GameObject TasseFull;
    private GameObject huhnRdy;

    void OnTriggerEnter(Collider other)
    {
        TasseFull = GameObject.FindGameObjectWithTag("TasseFull");
        pizzaRdy = GameObject.FindGameObjectWithTag("PizzaRdy");
        APizza = GameObject.FindGameObjectWithTag("APizza");
        huhnRdy = GameObject.FindGameObjectWithTag("huhnRdy");

        if(other.gameObject.CompareTag("TasseFull")) {         
            bool isRecipe = randomRecipe.isRecipeThere("CoffeeRecipe");
            if(isRecipe){
                score.increaseScore(5); 
                randomRecipe.destroyRecipe("CoffeeRecipe");
                recipeCrafting.ausgabeCall();
            }
        }

        if(other.gameObject.CompareTag("PizzaRdy")){
            bool isRecipe = randomRecipe.isRecipeThere("PizzaRecipe");
            if(isRecipe){
                score.increaseScore(10);   
                randomRecipe.destroyRecipe("PizzaRecipe");
                recipeCrafting.ausgabeCall();
            }
        }

// TODO: add the if needed like above
        if(other.gameObject.CompareTag("APizza") /* && it's needed*/){
            score.increaseScore(10);   
            randomRecipe.destroyRecipe("PizzaRecipe");
            recipeCrafting.ausgabeCall();
        }

        if(other.gameObject.CompareTag("huhnRdy") /* && it's needed*/){
            score.increaseScore(10);   
            randomRecipe.destroyRecipe("PizzaRecipe");
            recipeCrafting.ausgabeCall();
        }
    }
}
