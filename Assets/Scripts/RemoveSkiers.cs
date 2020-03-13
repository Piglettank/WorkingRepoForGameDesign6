using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSkiers : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("skierblue"))
        {
            Destroy(collider.gameObject);
            SkiersSpawner.enemyCount--;
        }
    }

}
