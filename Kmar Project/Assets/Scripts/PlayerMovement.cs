using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 direction;

    [Header("MovementStats")]

    [SerializeField] float strength; //jump strength
    [SerializeField] float speed;    //forward movementspeed

    [HideInInspector]
    public bool alive = true;

    void Update()
    {
        if (alive == true)
        {
            //player input to jump, fuel gets removed when jumping
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                GetComponent<Rigidbody>().velocity = Vector3.up * strength;
                GetComponent<PlayerStats>().fuel -= 10 * Time.deltaTime;
            }
        }

        //Y movement clamping stops the player from flying outside of the screen
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -5.1f, 9.5f);
        transform.position = clampedPosition;
    }
    //player gets moved 
    private void FixedUpdate()
    {
        transform.position += direction * Time.deltaTime;
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
