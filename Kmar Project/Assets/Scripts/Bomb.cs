using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            return;
        }
        else
        {
            Destroy(gameObject);
            if (collision.gameObject.tag == "Enemy")
            {
                GameManager.instance.points++;
                GameManager.instance.pointsText.text = "Kills: " + GameManager.instance.points;
                Destroy(collision.gameObject);
            }
        }
    }
}
