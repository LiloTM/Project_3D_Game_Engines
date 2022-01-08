using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float movementSpeed = 1f;

    private float angle;
    
    
    void Start(){
       
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        angle += moveHorizontal*0.01f;
        Vector3 targetDirection = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle));

        transform.rotation = Quaternion.LookRotation(targetDirection);
        
        transform.position += moveVertical * movementSpeed * transform.forward * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        
    }

}
