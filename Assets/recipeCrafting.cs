using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recipeCrafting : MonoBehaviour
{
    private GameObject pizzaFrozen;
    private GameObject pizzaRdy;
    public Slider cookingSlider;
    

    // Start is called before the first frame update
    void Start()
    {
        pizzaFrozen = GameObject.FindGameObjectWithTag("PizzaFrozen");
        pizzaFrozen.SetActive(false);
        pizzaRdy = GameObject.FindGameObjectWithTag("PizzaRdy");
        pizzaRdy.SetActive(false);

        //cookingSlider.gameObject.SetActive(true);
        cookingSlider.value = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(cookingSlider.gameObject.activeSelf){
            cookingSlider.value = cookingSlider.value + 2;
        } 
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Fridge")){
            pizzaFrozen.SetActive(true);
        }

        if (other.CompareTag("Herd")){
            pizzaFrozen.SetActive(false);
            cookingSlider.gameObject.SetActive(true);
        }

        if(cookingSlider.value == 500){
            pizzaRdy.SetActive(true);
            cookingSlider.gameObject.SetActive(false);
        }
    }
}
