using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public const float maxHealth = 100f;
    public float currentHealth = maxHealth;
    public const float maxfuel = 300f;
    public float fuel;

    // Update is called once per frame
    void Update()
    {
        //fuel
        fuel -= 1 * Time.deltaTime;
        GameManager.instance.fuelbarImage.fillAmount = fuel / maxfuel;

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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        GameManager.instance.healthbarImage.fillAmount = currentHealth / maxHealth;
    }

    public void Die()
    {
        GetComponent<PlayerMovement>().alive = false;
        Invoke("EndPlayer", 2f);
    }

    void EndPlayer()
    {
        gameObject.SetActive(false);
        GameManager.instance.gameOverScreen.SetActive(true);
    }


}
