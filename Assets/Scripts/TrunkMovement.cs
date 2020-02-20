using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkMovement : MonoBehaviour
{
    Rigidbody rb;

    Vector3 forceVectorX;

    //public float torque = 100f;
    public float force = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        forceVectorX = new Vector3(force, 0f, 0f);
    }

    void KeyInputTrunk()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // FORCE
            rb.AddForce(forceVectorX);

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // FORCE
            rb.AddForce(-forceVectorX);
        }
    }

    void MouseInputTrunk()
    {
        float horizontal = Input.GetAxis("Mouse X") * force;
        float vertical = Input.GetAxis("Mouse Y") * force;

        rb.AddForce(0, 0f, -horizontal);
        rb.AddForce(vertical, 0f, 0f);        
    }

    void FixedUpdate()
    {
        //KeyInputTrunk();
        MouseInputTrunk();
    }
}
