using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float t;
    public Text timerText;
    private bool finished;

    void Start(){
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        if(!finished){
            t -= Time.deltaTime;
            if (t < 0) {
                Debug.Log("STOOOOOOP the Game");
                finished = true;
            }

            string minutes = ((int)t / 60).ToString();
            float secondsFloat = (t % 60);
            string seconds;

            if(secondsFloat <= 9) seconds = "0" + secondsFloat.ToString("f0");
            else seconds = secondsFloat.ToString("f0");

            timerText.text = minutes + ":" + seconds;
        }
        
    }
}
