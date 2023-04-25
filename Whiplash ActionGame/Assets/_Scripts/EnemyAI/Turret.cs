using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{

    Transform player;
    float distance;
    public float maxDistance;
    public Transform head, barrel;
    public GameObject projectile;
    public float fireRate, fireNext, fireSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        if (distance <= maxDistance)
        {
            head.LookAt(player);
            if (Time.time >= fireNext)
            {
                fireNext = Time.time + 1f / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject clone =Instantiate(projectile, barrel.position, transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * fireSpeed);
    }
}
