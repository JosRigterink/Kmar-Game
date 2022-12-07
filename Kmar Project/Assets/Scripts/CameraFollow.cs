using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;

    void Start()
    {
        //camera offset
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        //camera follows player
        Vector3 targetPos = player.position + offset;
        targetPos.x = 10;
        targetPos.y = 4;
        transform.position = targetPos;
    }
}
