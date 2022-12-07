using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public const float maxHealth = 100f;
    public const float maxfuel = 300f;

    public float currentHealth = maxHealth;
    public float fuel;

    void Update()
    {
        //fuel decreases every second and fuelbar will update
        fuel -= 1 * Time.deltaTime;
        GameManager.instance.fuelbarImage.fillAmount = fuel / maxfuel;

        //if fuel is empty you die
        if (fuel <= 0)
        {
            Die();
            fuel = 0;
        }

        //if health is 0 you die
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //if you take damage the player health will be - the damage 
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        GameManager.instance.healthbarImage.fillAmount = currentHealth / maxHealth;
    }

    //die function sets alive bool to false and invokes EndPlayer function
    public void Die()
    {
        GetComponent<PlayerMovement>().alive = false;
        Invoke("EndPlayer", 2f);
    }

    //endplayer disables player and turns on gameOverScreen
    void EndPlayer()
    {
        gameObject.SetActive(false);
        GameManager.instance.gameOverScreen.SetActive(true);
    }


}
