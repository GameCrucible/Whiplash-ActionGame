using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    GameObject tempForBlock;
    public float journeyTime = 1.0f;

    // The time at which the animation started.
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnCoins();
        startTime = Time.time;
        //SpawnBlock();
        
    }

    void OnTriggerExit(Collider other)// other is default
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2); //destroy two seconds after player leaves trigger
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        //choose random point to spawn
        int obstacleSpawnIndex = Random.Range(2,5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //spawn at that position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform); 
    }

    public GameObject coinPrefab;


    void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for( int i = 0; i < coinsToSpawn; i++){
            GameObject temp = Instantiate(coinPrefab, transform);// attaches coins to the tile
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if(point !=collider.ClosestPoint(point)){ //checks if random point is on collider. should never be outside of the collider
            point = GetRandomPointInCollider(collider);
        }
        //point.y =1;
        point.y = collider.bounds.center.y + 1; // from the middle of the collider to slightly above
        return point;
    }

    public GameObject blockPrefab;

    void SpawnBlock()
    {
        //choose random point to spawn
        //int obstacleSpawnIndex = Random.Range(2,5);
        GameObject temp = Instantiate(blockPrefab, transform);// attaches block to the tile
        float smooth = (Time.time - startTime) / journeyTime;
        temp.transform.position = Vector3.Slerp(transform.position, groundSpawner.transform.position, 0.5f);
        //transform.position = Vector3.Lerp(transform.position, targetPos, smooth);
    }
}
