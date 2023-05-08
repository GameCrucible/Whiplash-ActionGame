using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public float leftAndRightBound = 10f;
    public float upAndDownBound = 11f;
    //public int rightBound;
    public GameObject groundTile;
    Vector3 nextSpawnPoint;
    Vector3 nextSpawnPointVertical;
    Vector3 nextSpawnPointHorizontal;
    int numTiles = 3;
    bool multilevel = false; 


    public void SpawnTile(){
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);

        if(multilevel==false){
            nextSpawnPoint = temp.transform.GetChild(8).transform.position; //keeps going straight and level
        }else{

            int groundTileSpawnIndexHorizontal = Random.Range(5,8);
            int groundTileSpawnIndexVertical = Random.Range(8,10);
            if( leftAndRightBound<temp.transform.position.x){// too far left
                groundTileSpawnIndexHorizontal = Random.Range(6,8);
            } else if( temp.transform.position.x<-leftAndRightBound){//too far rights
                groundTileSpawnIndexHorizontal = Random.Range(5,7);

            } else{
                groundTileSpawnIndexHorizontal = Random.Range(5,8);
            }
            nextSpawnPointHorizontal = temp.transform.GetChild(groundTileSpawnIndexHorizontal).transform.position;
/*
            if( upAndDownBound<temp.transform.position.y){// too far up
                groundTileSpawnIndexVertical = 10;
            } else if( 0>temp.transform.position.y){// too far up
                groundTileSpawnIndexVertical = 9;
            }else{
                groundTileSpawnIndexVertical = Random.Range(8,11);
            }
            */
            //groundTileSpawnIndexVertical = Random.Range(8,11);
            groundTileSpawnIndexVertical = 8;
            nextSpawnPointVertical = temp.transform.GetChild(groundTileSpawnIndexVertical).transform.position;


            Vector3 newPosition = new Vector3(nextSpawnPointHorizontal.x, nextSpawnPointVertical.y, nextSpawnPointHorizontal.z);

            nextSpawnPoint = newPosition;

            
            /* just left or right tiles. 
            int groundTileSpawnIndex = Random.Range(5,8);
            if( leftAndRightBound<temp.transform.position.x){// too far left
                groundTileSpawnIndex = Random.Range(6,8);
            } else if( temp.transform.position.x<-leftAndRightBound){//too far rights
                groundTileSpawnIndex = Random.Range(5,7);

            } else{
                groundTileSpawnIndex = Random.Range(5,8);
            }
            nextSpawnPoint = temp.transform.GetChild(groundTileSpawnIndex).transform.position;
            */

        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        for( int i = 0; i < numTiles; i++){
        SpawnTile();
        }
        


    }

}
