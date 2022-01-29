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
    private Controls controls;
    //private recipeCrafting r;
    
    /*
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
    */

    private void Start()
    {
        //r = GetComponent<recipeCrafting>();
    }

    void Update()
    {
        //PlayerInteraction();

        //movementInput = controls.Gameplay.Move.ReadValue<Vector2>();
        PlayerMovement();
    }

    void PlayerMovement()
    {
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

    /*void PlayerInteraction()
    {
        if (controls.Gameplay.Action.triggered)
        {
            r.SetTrue();
            Debug.Log("Knopf");
        }
        else {
            r.SetFalse();
        }
    }*/
}
