using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 direction;
    public float strength;
    public float speed;
    public float fuel;

    public bool alive = true;

    // Update is called once per frame
    void Update()
    {
        if (alive == true)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                GetComponent<Rigidbody>().velocity = Vector3.up * strength;
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        //fuel
        fuel -= 2 * Time.deltaTime;
        
        if (fuel <= 0)
        {
            fuel = 0;
            alive = false;
        }

        //clamping
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -5.1f, 10.0f);
        transform.position = clampedPosition;
    }

    private void FixedUpdate()
    {
        transform.position += direction * Time.deltaTime;
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
