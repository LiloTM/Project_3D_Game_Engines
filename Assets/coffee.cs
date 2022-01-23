using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coffee : MonoBehaviour
{
    public Slider cookingSliderKaffee;

    public GameObject coffeeTimer;
    // Start is called before the first frame update
    void Start()
    {
        // Slider zuweisen
        //cookingSliderKaffee = GameObject.FindGameObjectWithTag("KaffeeTimerChild").GetComponent<Slider>();
        cookingSliderKaffee = coffeeTimer.GetComponent<Slider>();
        cookingSliderKaffee.value = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cookingSliderKaffee.gameObject.activeSelf)
        {
            cookingSliderKaffee.value = cookingSliderKaffee.value + 2;
        }
    }
}
