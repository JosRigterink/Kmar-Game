using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    //if the player collides with the fuel sphere his fuel will get back to max.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().fuel = 300f;
            Destroy(gameObject);
        }
    }
}
