using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    [Header("BombDropstats")]

    [SerializeField] GameObject bombPrefab; //bombObject
    public float dropCooldown; //drop cooldowntime

    private bool canDrop = true;

    void Update()
    {
        //when player presses correct key and cooldown is over drop bomb and start cooldown
        if (Input.GetKeyDown(KeyCode.E) && canDrop == true || Input.GetMouseButtonDown(1) && canDrop == true)
        {
            canDrop = false;
            GameObject bomb = Instantiate(bombPrefab,transform.position, Quaternion.identity);
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        //can drop bomb cooldown
        yield return new WaitForSeconds(dropCooldown);
        canDrop = true;
    }
}
