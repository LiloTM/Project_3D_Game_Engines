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
    private GameObject Ananas;
    private GameObject APizza;
    private GameObject AnanasCutted1;
    private GameObject AnanasCutted2;
    private GameObject huhnFrozen;
    private GameObject huhnRdy;

    //private bool knopfdruck;

    public Slider cookingSliderHerd;
    public Slider cookingSliderKaffee;
    public Slider cookingSliderAnanas;
    bool carrying, carryFrozen, carryTeller, carryPizza, carryTasseEmpty, carryTasseFull, cupMaker;
    bool carryAnanas, carryAPizza, carryHuhnFrozen, carryHuhnRdy, pizzamaking, huhnmaking;

    int blubscore;

    private Controls controls;
    public Score score;
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
        Ananas = GameObject.FindGameObjectWithTag("Ananas");
        Ananas.SetActive(false);
        AnanasCutted1 = GameObject.FindGameObjectWithTag("AnanasCutted1");
        AnanasCutted1.SetActive(false);
        AnanasCutted2 = GameObject.FindGameObjectWithTag("AnanasCutted2");
        AnanasCutted2.SetActive(false);
        APizza = GameObject.FindGameObjectWithTag("APizza");
        APizza.SetActive(false);
        huhnFrozen = GameObject.FindGameObjectWithTag("huhnFrozen");
        huhnFrozen.SetActive(false);
        huhnRdy = GameObject.FindGameObjectWithTag("huhnRdy");
        huhnRdy.SetActive(false);

        //cookingSlider.gameObject.SetActive(true);
        cookingSliderHerd.value = 0;
        cookingSliderKaffee.value = 0;
        cookingSliderAnanas.value = 0;
        carrying = false;
        carryFrozen = false;
        carryTeller = false;
        carryPizza = false;
        carryTasseEmpty = false;
        carryTasseFull = false;
        cupMaker = false;
        carryAnanas = false;
        carryAPizza = false;
        carryHuhnFrozen = false;
        carryHuhnRdy = false;
        pizzamaking = false;
        huhnmaking = false;

        blubscore = 0;

        //knopfdruck = false;
    }
    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
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
        if(cookingSliderAnanas.gameObject.activeSelf){
            cookingSliderAnanas.value = cookingSliderAnanas.value + 2;
        }
        

        if(cookingSliderAnanas.value > 250){
            AnanasCutted1.SetActive(false);
            AnanasCutted2.SetActive(true);
        }
        
        blubscore = score.getScore();
    }

    /*public void SetTrue() 
    {
        knopfdruck = true;
    }
    public void SetFalse()
    {
        knopfdruck = false;
    }*/

    private void OnTriggerStay(Collider other) {
        //Basic Items 
            if (other.CompareTag("Fridge") && carrying == false && controls.Gameplay.Action.triggered)
            {
                pizzaFrozen.SetActive(true);
                carryFrozen = true;
                carrying = true;
            }
            if (other.CompareTag("FridgeHuhn") && carrying == false)
            {
                huhnFrozen.SetActive(true);
                carryHuhnFrozen = true;
                carrying = true;
            }
            if (other.CompareTag("AnanasBox") && carrying == false)
            {
                Ananas.SetActive(true);
                carryAnanas = true;
                carrying = true;
            }
            if (other.CompareTag("Teller") && carrying == false)
            {
                tellerEmpty.SetActive(true);
                carryTeller = true;
                carrying = true;
            }
            if (other.CompareTag("Tasse") && carrying == false)
            {
                TasseEmpty.SetActive(true);
                carryTasseEmpty = true;
                carrying = true;
            }
            //################################################################
            // craft stations starting
            if (other.CompareTag("Brett") && carryAnanas == true)
            {

                Ananas.SetActive(false);
                AnanasCutted1.SetActive(true);
                cookingSliderAnanas.gameObject.SetActive(true);
                carryAnanas = false;
                carrying = false;
            }
            if (other.CompareTag("Herd") && carryFrozen == true && cookingSliderHerd.value < 2 && controls.Gameplay.Action.triggered)
            {
                pizzaFrozen.SetActive(false);
                cookingSliderHerd.gameObject.SetActive(true);
                carryFrozen = false;
                carrying = false;
                pizzamaking = true;
            }
            if (other.CompareTag("Herd") && carryHuhnFrozen == true && cookingSliderHerd.value < 2)
            {
                huhnFrozen.SetActive(false);
                cookingSliderHerd.gameObject.SetActive(true);
                carryHuhnFrozen = false;
                carrying = false;
                huhnmaking = true;
            }
            if (other.CompareTag("Coffee") && carryTasseEmpty == true && cupMaker == false)
            {
                TasseEmpty.SetActive(false);
                cookingSliderKaffee.gameObject.SetActive(true);
                TasseMaker.gameObject.SetActive(true);
                cupMaker = true;
                carryTasseEmpty = false;
                carrying = false;
            }
            //################################################################
            // craft stations finished
            if (cookingSliderAnanas.value == 750 && other.CompareTag("Brett") && carryPizza == true)
            {
                APizza.SetActive(true);
                cookingSliderAnanas.gameObject.SetActive(false);
                pizzaRdy.SetActive(false);
                AnanasCutted2.SetActive(false);
                carryPizza = false;
                carryAPizza = true;
                cookingSliderAnanas.value = 0;
            }
            if (cookingSliderHerd.value == 1000 && other.CompareTag("Herd") && carryTeller == true && pizzamaking == true)
            {
                pizzaRdy.SetActive(true);
                cookingSliderHerd.gameObject.SetActive(false);
                tellerEmpty.SetActive(false);
                carryTeller = false;
                carrying = true;
                carryPizza = true;
                cookingSliderHerd.value = 0;
                pizzamaking = false;
            }
            if (cookingSliderHerd.value == 1000 && other.CompareTag("Herd") && carryTeller == true && huhnmaking == true)
            {
                huhnRdy.SetActive(true);
                cookingSliderHerd.gameObject.SetActive(false);
                tellerEmpty.SetActive(false);
                carryTeller = false;
                carrying = true;
                carryHuhnRdy = true;
                cookingSliderHerd.value = 0;
                huhnmaking = false;
            }
            if (cookingSliderKaffee.value == 750 && other.CompareTag("Coffee") && carrying == false && cupMaker == true)
            {
                TasseFull.SetActive(true);
                cookingSliderKaffee.gameObject.SetActive(false);
                TasseMaker.gameObject.SetActive(false);
                carryTasseFull = true;
                carrying = true;
                cupMaker = false;
                cookingSliderKaffee.value = 0;
            }
            //################################################################
            // trashbin
            if (other.CompareTag("Trash"))
            {
                ausgabeCall();
            }
    }
    private void OnTriggerEnter(Collider other) {
                if (other.CompareTag("Trash") && blubscore > 9){
                score.decreaseScore(10);
                }
                if (other.CompareTag("Trash") && blubscore < 10){
                score.setZero();
                }
            }
    public void ausgabeCall(){
            pizzaFrozen.SetActive(false);
            pizzaRdy.SetActive(false);
            tellerEmpty.SetActive(false);
            TasseFull.SetActive(false);
            TasseEmpty.SetActive(false);
            Ananas.SetActive(false);
            APizza.SetActive(false);
            huhnFrozen.SetActive(false);
            huhnRdy.SetActive(false);
            carrying = false;
            carryFrozen = false;
            carryTeller = false;
            carryPizza = false;
            carryTasseEmpty = false;
            carryTasseFull = false;
            carryAnanas = false;
            carryAPizza = false;
            carryHuhnFrozen = false;
            carryHuhnRdy = false;
    }
}
