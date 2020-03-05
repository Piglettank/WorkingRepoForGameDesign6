using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject circle;

    private Rigidbody rb;
    private Transform transformChildren;

    public float moveSpeed;
    public float rotationSpeed;

    private Vector3 target;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transformChildren = GetComponentInChildren<Transform>();
    }

    void Movement()
    {
        // GOING RIGHT
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(moveSpeed, 0, 0);
            //rb.AddForce(transform.right * moveSpeed);
            //rb.AddTorque(transform.right * rotationSpeed);
            // Spin the object around the world origin at 20 degrees/second.
            transformChildren.RotateAround(circle.transform.position, Vector3.forward, 100 * Time.deltaTime);
        }
        // GOING LEFT
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-moveSpeed, 0, 0);
            //rb.AddForce(-transform.right * moveSpeed);
            //rb.AddTorque(-transform.right * rotationSpeed);
            transformChildren.RotateAround(circle.transform.position, -Vector3.forward, 100 * Time.deltaTime);
        }
        // GOING UP
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, 0, moveSpeed);
            //rb.AddForce(transform.forward * moveSpeed);
            //rb.AddTorque(transform.forward * rotationSpeed);
        }
        // GOING DOWN
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, 0, -moveSpeed);
            //rb.AddForce(-transform.forward * moveSpeed);
            //rb.AddTorque(-transform.forward * rotationSpeed);
        }
    }

    void FixedUpdate()
    {
        Movement();
    }
}
