using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public static int bananaCount = 0;

    void Start()
    {
        bananaCount = 1;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Bounce");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // WHEN BANANA COLLIDES WITH MOUTH
        if (collider.gameObject.tag == "Mouth")
        {
            // DESTROYS THE GAMEOBJECT
            Debug.Log("Banana Eaten");
            Destroy(gameObject);
            bananaCount--;
            // INSERT SFX
        }
    }

    void Update()
    {

    }
}
