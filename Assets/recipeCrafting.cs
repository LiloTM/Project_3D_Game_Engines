using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recipeCrafting : MonoBehaviour
{
    private GameObject pizzaFrozen;
    private GameObject pizzaRdy;
    private GameObject tellerEmpty;
    private GameObject TasseFull;
    private GameObject TasseEmpty;
    private GameObject TasseMaker;

    public Slider cookingSliderHerd;
    public Slider cookingSliderKaffee;
    bool carrying, carryFrozen, carryTeller, carryPizza, carryTasseEmpty, carryTasseFull, cupMaker;

    // Start is called before the first frame update
    void Start()
    {
        pizzaFrozen = GameObject.FindGameObjectWithTag("PizzaFrozen");
        pizzaFrozen.SetActive(false);
        pizzaRdy = GameObject.FindGameObjectWithTag("PizzaRdy");
        pizzaRdy.SetActive(false);
        tellerEmpty = GameObject.FindGameObjectWithTag("Teller");
        tellerEmpty.SetActive(false);
        TasseFull = GameObject.FindGameObjectWithTag("TasseFull");
        TasseFull.SetActive(false);
        TasseEmpty = GameObject.FindGameObjectWithTag("TasseEmpty");
        TasseEmpty.SetActive(false);
        TasseMaker = GameObject.FindGameObjectWithTag("TasseMaker");
        TasseMaker.SetActive(false);

        //cookingSlider.gameObject.SetActive(true);
        cookingSliderHerd.value = 0;
        cookingSliderKaffee.value = 0;
        carrying = false;
        carryFrozen = false;
        carryTeller = false;
        carryPizza = false;
        carryTasseEmpty = false;
        carryTasseFull = false;
        cupMaker = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(cookingSliderHerd.gameObject.activeSelf){
            cookingSliderHerd.value = cookingSliderHerd.value + 2;
        } 
        if(cookingSliderKaffee.gameObject.activeSelf){
            cookingSliderKaffee.value = cookingSliderKaffee.value + 2;
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Fridge") && carrying == false){
            pizzaFrozen.SetActive(true);
            carryFrozen = true;
            carrying = true;
        }

        if (other.CompareTag("Herd") && carryFrozen == true){
            pizzaFrozen.SetActive(false);
            cookingSliderHerd.gameObject.SetActive(true);
            carryFrozen = false;
            carrying = false;
        }

        if (other.CompareTag("Teller") && carrying == false){
            tellerEmpty.SetActive(true);
            carryTeller = true;
            carrying = true;
        }

        if(cookingSliderHerd.value == 500 && other.CompareTag("Herd") && carryTeller == true){
            pizzaRdy.SetActive(true);
            cookingSliderHerd.gameObject.SetActive(false);
            tellerEmpty.SetActive(false);
            carryTeller = false;
            carrying = true;
            carryPizza = true;
            cookingSliderHerd.value = 0;
        }

        if(other.CompareTag("Tasse") && carrying == false){
            TasseEmpty.SetActive(true);
            carryTasseEmpty = true;
            carrying = true;
        }

        if (other.CompareTag("Coffee") && carryTasseEmpty == true && cupMaker == false){
            TasseEmpty.SetActive(false);
            cookingSliderKaffee.gameObject.SetActive(true);
            TasseMaker.gameObject.SetActive(true);
            cupMaker = true;
            carryTasseEmpty = false;
            carrying = false;
        }

        if(cookingSliderKaffee.value == 500 && other.CompareTag("Coffee") && carrying == false && cupMaker == true){
            TasseFull.SetActive(true);
            cookingSliderKaffee.gameObject.SetActive(false);
            TasseMaker.gameObject.SetActive(false);
            carryTasseFull = true;
            carrying = true;
            cupMaker = false;
            cookingSliderKaffee.value = 0;
        }

        if(other.CompareTag("Trash")){
            pizzaFrozen.SetActive(false);
            pizzaRdy.SetActive(false);
            tellerEmpty.SetActive(false);
            TasseFull.SetActive(false);
            TasseEmpty.SetActive(false);
            carrying = false;
            carryFrozen = false;
            carryTeller = false;
            carryPizza = false;
            carryTasseEmpty = false;
            carryTasseFull = false;
        }
    }
}
