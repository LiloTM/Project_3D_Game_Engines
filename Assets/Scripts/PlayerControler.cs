using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    private Vector2 movementInput;

    private void Start(){
    }

    void Update(){
        PlayerMovement();
    }

    void PlayerMovement(){
        float ver = movementInput.x;
        float hor = movementInput.y;
        Vector3 playerMovement = new Vector3(hor, 0f, -ver);
        playerMovement.Normalize();
        transform.Translate(playerMovement * speed * Time.deltaTime, Space.World);

        if (playerMovement != Vector3.zero) 
        {
            Quaternion toRotation = Quaternion.LookRotation(playerMovement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
