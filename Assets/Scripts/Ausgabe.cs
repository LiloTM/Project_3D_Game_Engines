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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        TasseFull = GameObject.FindGameObjectWithTag("TasseFull");
        pizzaRdy = GameObject.FindGameObjectWithTag("PizzaRdy");
        APizza = GameObject.FindGameObjectWithTag("APizza");
        huhnRdy = GameObject.FindGameObjectWithTag("huhnRdy");

        if(other.gameObject.CompareTag("TasseFull") /* && it's needed*/){
            score.increaseScore(5); 
            randomRecipe.destroyCoffeeRecipe();         
            recipeCrafting.ausgabeCall();
        }

        if(other.gameObject.CompareTag("PizzaRdy") /* && it's needed*/){
            Debug.Log("Hallo vor score");
            score.increaseScore(10);   
            randomRecipe.destroyPizzaRecipe();
            Debug.Log("Hallo nach Score");
            recipeCrafting.ausgabeCall();
        }

        if(other.gameObject.CompareTag("APizza") /* && it's needed*/){
            score.increaseScore(10);   
            randomRecipe.destroyPizzaRecipe();
            recipeCrafting.ausgabeCall();
        }

        if(other.gameObject.CompareTag("huhnRdy") /* && it's needed*/){
            score.increaseScore(10);   
            randomRecipe.destroyPizzaRecipe();
            recipeCrafting.ausgabeCall();
        }
    }
}
