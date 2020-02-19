using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 torqueVectorZ;
    Vector3 torqueVectorY;
    Vector3 torqueVectorX;

    Vector3 forceVectorZ;
    Vector3 forceVectorY;
    Vector3 forceVectorX;

    public float torque = 100f;
    public float force = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        torqueVectorZ = new Vector3(0f, 0f, torque);
        torqueVectorY = new Vector3(0f, torque, 0f);
        torqueVectorX = new Vector3(torque, 0f, 0f);

        forceVectorZ = new Vector3(0f, 0f, force);
        forceVectorY = new Vector3(0f, force, 0f);
        forceVectorZ = new Vector3(force, 0f, 0f);
        
    }

    void Trunk()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // FORCE
            rb.AddForce(forceVectorZ);
            //rb.AddForce(forceVectorY);
            //rb.AddForce(forceVectorX);

            // TORQUE (ROTATION)
            //rb.AddTorque(vectorZ);
            //rb.AddTorque(vectorY);
            //rb.AddTorque(vectorX);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // FORCE
            rb.AddForce(-forceVectorZ);
            //rb.AddForce(-forceVectorY);
            //rb.AddForce(-forceVectorX);

            // TORQUE (ROTATION)
            //rb.AddTorque(-vectorZ);
            //rb.AddTorque(-vectorY);
            //rb.AddTorque(-vectorX);
        }

    }

    void FixedUpdate()
    {
        Trunk();
    }
}
