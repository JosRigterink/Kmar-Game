using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    private void OnCollisionEnter(Collision collision)
    {
        //if the bomb collides with the player do nothing
        if (collision.gameObject.tag == "Player")
        {
            return;
        }
        else
        {
            //destroys bomb and instantiates explosion effect
            Destroy(gameObject);
            GameObject explosion =  Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(explosion, 1);

            //if the bomb collides with the Enemy a kill is added the UI gets updated and the Enemy is destroyed
            if (collision.gameObject.tag == "Enemy")
            {
                GameManager.instance.kills++;
                GameManager.instance.pointsText.text = "Kills: " + GameManager.instance.kills;
                Destroy(collision.gameObject);
            }
        }
    }
}
