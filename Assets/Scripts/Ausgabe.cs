using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ausgabe : MonoBehaviour
{
    public Score score;
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
        }

        if(other.gameObject.CompareTag("Pizza") /* && it's needed*/){
            Destroy(other.gameObject);
            score.increaseScore(10);   
        }
    }
}
