using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{
    //Done by Christopher DePalma
    Transform player; //Player Object
    float distance; //How far the player is from the turret
    public float maxDistance; //The range of the turret's detection
    public Transform head, barrel; //The parts of the turret manipulated by the code
    public GameObject projectile; //The projectile prefab
    public float fireRate, fireNext, fireSpeed; //How fast, often, and quickly it fires
    public AudioSource audio; //For the shoot audio

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //Finds the player by its tag
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position); //Finds how fast the player is from the turret
        if (distance <= maxDistance) //If within the turret's range, fire
        {
            head.LookAt(player); //Turns the head to face the player when firing
            if (Time.time >= fireNext) //Making sure the turret hasn't fired recently
            {
                fireNext = Time.time + 1f / fireRate; //Determines how often the turret can fire (adjustable)
                Shoot(); //Fires
            }
        }
    }

    void Shoot()
    {
        audio.Play();
        GameObject clone =Instantiate(projectile, barrel.position, transform.rotation); //Spawns the projectile at the gun's barrel
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * fireSpeed); //Adds force to the projectile to fire it
    }
}
