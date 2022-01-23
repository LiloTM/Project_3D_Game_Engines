using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recipeNew : MonoBehaviour
{
    private microwave Microwave;

    public GameObject pizzaFrozen;
    public GameObject pizzaRdy;
    public GameObject tellerEmpty;
    public GameObject TasseFull;
    public GameObject TasseEmpty;
    public GameObject TasseMaker;

    public bool carrying, carryFrozen, carryTeller, carryPizza, carryTasseEmpty, carryTasseFull, cupMaker;

    // Start is called before the first frame update
    void Start()
    {
        Microwave = GameObject.Find("HerdTimer").GetComponent<microwave>();

        /*pizzaFrozen = GameObject.FindGameObjectWithTag("PizzaFrozen");
        pizzaRdy = GameObject.FindGameObjectWithTag("PizzaRdy");
        tellerEmpty = GameObject.FindGameObjectWithTag("Teller");
        TasseFull = GameObject.FindGameObjectWithTag("TasseFull");
        TasseEmpty = GameObject.FindGameObjectWithTag("TasseEmpty");
        TasseMaker = GameObject.FindGameObjectWithTag("TasseMaker");*/
        TasseEmpty.SetActive(false);
        TasseFull.SetActive(false);
        tellerEmpty.SetActive(false);
        pizzaRdy.SetActive(false);
        pizzaFrozen.SetActive(false);
        TasseMaker.SetActive(false);

        carrying = false;
        carryFrozen = false;
        carryTeller = false;
        carryPizza = false;
        carryTasseEmpty = false;
        carryTasseFull = false;
        cupMaker = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Fridge") && carrying == false){
            pizzaFrozen.SetActive(true);
            carryFrozen = true;
            carrying = true;
        }

        if (other.CompareTag("Teller") && carrying == false){
            tellerEmpty.SetActive(true);
            carryTeller = true;
            carrying = true;
        }
        if (other.CompareTag("Herd"))
        {
            if (carryFrozen == true)
            {
                pizzaFrozen.SetActive(false);
                other.gameObject.GetComponent<microwave>().SetTrue();
                carryFrozen = false;
                carrying = false;
            }

            if (other.GetComponent<microwave>().GetValue() == 500  && carryTeller == true)
            {
                pizzaRdy.SetActive(true);
                other.gameObject.GetComponent<microwave>().SetFalse();
                tellerEmpty.SetActive(false);
                carryTeller = false;
                carrying = true;
                carryPizza = true;
                other.gameObject.GetComponent<microwave>().SetValue(0);
            }
        }

        if(other.CompareTag("Tasse") && carrying == false){
            TasseEmpty.SetActive(true);
            carryTasseEmpty = true;
            carrying = true;
        }

        if (other.CompareTag("Coffee"))
        {
            if (carryTasseEmpty == true && cupMaker == false)
            {
                TasseEmpty.SetActive(false);
                other.GetComponent<coffee>().cookingSliderKaffee.gameObject.SetActive(true);
                TasseMaker.gameObject.SetActive(true);
                cupMaker = true;
                carryTasseEmpty = false;
                carrying = false;
            }

            if (other.GetComponent<coffee>().cookingSliderKaffee.value == 500 && carrying == false && cupMaker == true)
            {
                TasseFull.SetActive(true);
                other.GetComponent<coffee>().cookingSliderKaffee.gameObject.SetActive(false);
                TasseMaker.gameObject.SetActive(false);
                carryTasseFull = true;
                carrying = true;
                cupMaker = false;
                other.GetComponent<coffee>().cookingSliderKaffee.value = 0;
            }
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
