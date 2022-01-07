using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Vector3 v3Force;
    [SerializeField] KeyCode keyPos;
    [SerializeField] KeyCode keyNeg;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(keyPos))
            GetComponent<Rigidbody>().velocity += v3Force;
        if (Input.GetKey(keyNeg))
            GetComponent<Rigidbody>().velocity -= v3Force;
    }
}
