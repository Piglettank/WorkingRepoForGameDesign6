using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public static int bananaCount = 0;

    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // WHEN BANANA COLLIDES WITH MOUTH
        if (collision.gameObject.tag == "Mouth")
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
