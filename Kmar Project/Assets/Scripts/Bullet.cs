using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; //bullet speed
    public float damage; //bullet damage

    void Update()
    {
        //bullet movement
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(transform.up * distanceThisFrame, Space.World);
    }

    //if bullet hits the player he does damage and destroys itself.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerStats>() == null)
        {
            return;
        }
        Debug.Log("destroyed itself");
        other.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
