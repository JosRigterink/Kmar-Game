using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public const float maxHealth = 100f;
    public float currentHealth = maxHealth;
    public float fuel;
   
    // Update is called once per frame
    void Update()
    {
        //fuel
        fuel -= 2 * Time.deltaTime;

        if (fuel <= 0)
        {
            Die();
            fuel = 0;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GetComponent<PlayerMovement>().alive = false;
        //Destroy(gameObject);
    }
}
