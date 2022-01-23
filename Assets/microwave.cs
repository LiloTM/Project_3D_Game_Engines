using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class microwave : MonoBehaviour
{
    public Slider cookingSliderHerd;
    //private Slider cookingSliderKaffee;

    public GameObject herdTimer;
    //private GameObject coffeeTimer;
    // Start is called before the first frame update
    void Start()
    {
        // Slider zuweisen

        //cookingSliderHerd = GameObject.FindGameObjectWithTag("HerdTimerChild").GetComponent<Slider>();
        cookingSliderHerd = herdTimer.GetComponent<Slider>();
        cookingSliderHerd.value = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cookingSliderHerd.gameObject.activeSelf)
        {
                cookingSliderHerd.value = cookingSliderHerd.value + 2;
        }     
    }

    public float GetValue() 
    {
        return cookingSliderHerd.value;
    }
    public void SetValue(float x)
    {
        cookingSliderHerd.value = x;
    }

    public void SetTrue()
    {
        cookingSliderHerd.gameObject.SetActive(true);
    }

    public void SetFalse()
    {
        cookingSliderHerd.gameObject.SetActive(false);
    }
}
