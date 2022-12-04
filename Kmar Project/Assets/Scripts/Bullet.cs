using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public void targetSeek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(transform.up * distanceThisFrame, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           Debug.Log("destroyed itself");
           Destroy(gameObject);
        }
    }
}
