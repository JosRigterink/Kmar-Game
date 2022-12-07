using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            return;
        }
        else
        {
            Destroy(gameObject);
            GameObject explosion =  Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(explosion, 1);
            if (collision.gameObject.tag == "Enemy")
            {
                GameManager.instance.kills++;
                GameManager.instance.pointsText.text = "Kills: " + GameManager.instance.kills;
                Destroy(collision.gameObject);
            }
        }
    }
}
