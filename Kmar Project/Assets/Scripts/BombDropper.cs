using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bombPrefab,transform.position, Quaternion.identity);
        }
    }
}
