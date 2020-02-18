using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 vector;

    public float torque = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vector = new Vector3(0f, 0f, torque);
    }

    void Trunk()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddTorque(vector);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddTorque(-vector);
        }
            
    }

    void FixedUpdate()
    {
        Trunk();
    }
}
