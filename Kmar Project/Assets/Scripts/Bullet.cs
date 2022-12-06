using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;

    // Update is called once per frame
    void Update()
    {
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(transform.up * distanceThisFrame, Space.World);
    }

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
