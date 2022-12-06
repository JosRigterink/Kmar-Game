using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    public float dropCooldown;
    private bool canDrop = true;

    void Start()
    {
        canDrop = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canDrop == true || Input.GetMouseButtonDown(1) && canDrop == true)
        {
            canDrop = false;
            GameObject bomb = Instantiate(bombPrefab,transform.position, Quaternion.identity);
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(dropCooldown);
        canDrop = true;
    }
}
