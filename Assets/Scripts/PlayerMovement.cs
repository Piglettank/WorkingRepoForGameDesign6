using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject circle;

    private Rigidbody rb;
    private Transform transformChildren;

    public static bool canMove = true;

    public float moveSpeed;
    public float rotationSpeed;
    public float rotationSpeedIncrement = 50f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transformChildren = GetComponentInChildren<Transform>();
    }

    void Movement()
    {
        // MOVEMENT
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        if (canMove)
        {
            // MOVEMENT
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
        else
        {
            rb.velocity = movement * 0;
        }
    }

    void RotationPowerUp()
    {
        // CHEAT CODE 
        // KEY G
        if (Input.GetKeyDown(KeyCode.G))
        {
            HitIndicator.rotationPower++;
        }

        if (HitIndicator.rotationPower >= 1)
        {
            HitIndicator.rotationPower--;
            rotationSpeed = rotationSpeed + rotationSpeedIncrement;
            Debug.Log(rotationSpeed);

        }
        else if (HitIndicator.rotationPower < 0)
        {
            HitIndicator.rotationPower++;
            rotationSpeed = rotationSpeed - rotationSpeedIncrement;
            Debug.Log(rotationSpeed);
        }

        // ROTATION LIMIT
        if (rotationSpeed < 50)
        {
            rotationSpeed = 50f;
        }
    }

    void FixedUpdate()
    {
        Movement();
        RotationPowerUp();
    }
}
