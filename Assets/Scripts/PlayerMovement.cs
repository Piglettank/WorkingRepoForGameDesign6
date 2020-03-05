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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transformChildren = GetComponentInChildren<Transform>();
    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rb.velocity = movement * moveSpeed;

        // ROTATION
        // ROTATES CLOCKWISE (RIGHT)
        if (moveHorizontal > 0)
        {
            transformChildren.RotateAround(circle.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        // ROTATES COUNTER-CLOCKWISE (LEFT)
        if (moveHorizontal < 0)
        {
            transformChildren.RotateAround(circle.transform.position, -Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // ROTATES CLOCKWISE (UP)
        if (moveVertical > 0)
        {
            transformChildren.RotateAround(circle.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        // ROTATES COUNTER-CLOCKWISE (DOWN)
        if (moveVertical < 0)
        {
            transformChildren.RotateAround(circle.transform.position, -Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        Movement();
    }
}
