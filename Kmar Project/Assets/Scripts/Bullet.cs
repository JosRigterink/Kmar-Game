using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

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
        other.gameObject.GetComponent<PlayerStats>().currentHealth -= 10f;
        Destroy(gameObject);
    }
}
