using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ausgabe : MonoBehaviour
{
    public Score score;
    public RandomRecipe randomRecipe;
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
        if(other.gameObject.CompareTag("Coffee") /* && it's needed*/){
            Destroy(other.gameObject);
            score.increaseScore(5); 
            randomRecipe.destroyCoffeeRecipe();         
        }

        if(other.gameObject.CompareTag("PizzaRdy") /* && it's needed*/){
            Destroy(other.gameObject);
            score.increaseScore(10);   
            randomRecipe.destroyPizzaRecipe();
        }
    }
}
