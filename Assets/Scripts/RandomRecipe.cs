using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRecipe : MonoBehaviour
{
    int random;
    int RecipeNumber = 0;
    int highestRecipeNumber = 8;
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
            if(RecipeNumber < highestRecipeNumber){
                switch(random){
                    case 1: drawRecipe(Kaffee); break;
                    case 2: drawRecipe(Pizza); break;
                }      
                RecipeNumber++;
            }
            
        }
    }

    void giveRandom(){
        random = Random.Range(1, 100);
        if(random<50) {random = 1;} else {random = 2;}
    }


    void drawRecipe(Transform newRecipeItem){
        Transform newRecipe = Instantiate (newRecipeItem, UI);     
        newRecipe.transform.position = newRecipe.position + new Vector3(RecipeNumber*180,0,0);
        allRecipes.Add(newRecipe);
    }

    public bool isRecipeThere(string tag){
        var checker = false;
        foreach(Transform item in allRecipes){
            if(item.CompareTag(tag) && checker==false){
                checker = true;
            }
            if(checker == true) break; 
        }
        return checker;
    }

    public void destroyRecipe(string tag){
        var checker = false;
        int index = 10000;
        foreach(Transform item in allRecipes){
            index = allRecipes.IndexOf(item);
            if(item.CompareTag(tag) && checker==false){
                Transform clone = allRecipes[index];
                allRecipes.RemoveAt(index);
                Destroy(clone.gameObject);
                checker = true;
                break;
            }
        }
        RecipeNumber--;
        if(checker == true && index != 10000) {
            for(int i = index; i<RecipeNumber;i++){
                allRecipes[i].transform.position = allRecipes[i].position - new Vector3(180,0,0); 
            }
        }
    }
    
}
