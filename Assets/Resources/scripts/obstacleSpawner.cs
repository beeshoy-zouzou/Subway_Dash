using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
	public GameObject curObstacle;
	public int obsCount;
	private float nextSpawn;
	public float spawnRate;
	public float[] posX;
	public float speed;
	
	public Transform player;
	public float range;
	public float dist;
	

	
    void Start()
    {	
		player = GameObject.Find("player").GetComponent<Transform>();
	
    }

    // Update is called once per frame
    void Update()
    {
		 dist = Vector3.Distance(transform.position,player.position);
		curObstacle = obstacles[obsCount];
		Vector3 posSpawn = new Vector3(posX[Random.Range(0,3)],transform.position.y,transform.position.z);
		
	if(dist > range){
		
        if(nextSpawn < Time.time){
			obsCount = Random.Range(0,6);
			spawnRate = Random.Range(0.5f,2.5f);
			nextSpawn = Time.time + spawnRate;
			
			
			if(curObstacle.name == "obstacle3"){
			
			Instantiate(curObstacle,transform.position,transform.rotation);
			
			}
			
			if(curObstacle.name != "obstacle3"){
			
			Instantiate(curObstacle,posSpawn,transform.rotation);
			
			}
			
			
			
			
			
		}
	}
	
	if(dist <= range) {
		
		
		nextSpawn = 0f;
		
		
	}
		
		
		
		
		
		
		
			
			
			
		
    }
}
