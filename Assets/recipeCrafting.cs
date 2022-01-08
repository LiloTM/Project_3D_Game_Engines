using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recipeCrafting : MonoBehaviour
{
    private GameObject pizzaFrozen;
    private GameObject pizzaRdy;

    // Start is called before the first frame update
    void Start()
    {
        pizzaFrozen = GameObject.FindGameObjectWithTag("PizzaFrozen");
        pizzaFrozen.SetActive(false);
        pizzaRdy = GameObject.FindGameObjectWithTag("PizzaRdy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Fridge")){
            pizzaFrozen.SetActive(true);
        }

        if (other.CompareTag("Herd")){
            pizzaFrozen.SetActive(false);
            //pizzaTimer.SetActive(true);
        }
    }
}
