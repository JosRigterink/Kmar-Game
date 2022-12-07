using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
    private Transform target;

    [Header("TurretStats")]

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("TurretSetupField")]

    public float turnspeed = 15f;

    public GameObject bulletPrefab;
    [HideInInspector]
    public Transform firePoint;
    [HideInInspector]
    public Transform rotatePart;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        //looks for nearest target
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;
        foreach (GameObject player in players)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestPlayer = player;
            }
        }

        //cant find target target is nothing
        if (nearestPlayer != null && shortestDistance <= range)
        {
            target = nearestPlayer.transform;
        }
        else
        {
            target = null;
        }

    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        //locks on nearest target and looks at it
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotatePart.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        rotatePart.rotation = lookRotation;
      
        //firerate of the turret
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    //turret shooting spawning bullets
    void Shoot()
    {
        Debug.Log("shoot!");
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();
        bulletGameObject.GetComponent<Bullet>().damage = damage;

        Destroy(bulletGameObject, 2f);
    }

    //deletes obstacle if obstacle and turret spawn at same spot
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Obstacle"))
        {
            Destroy(other.gameObject);
            return;
        }
    }
    //shows a detectsphere range of turret
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
