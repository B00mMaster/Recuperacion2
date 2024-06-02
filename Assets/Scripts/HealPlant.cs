using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlant : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
           //destroy when player collides plant
            Destroy(gameObject);

        }
    }
}
