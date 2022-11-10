using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMovement : MonoBehaviour
{
    public float speed; 
	 playerMovement pl;
	
	 
	
    void Start()
    {
        pl= GameObject.Find("player").GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
		speed = pl.speed;
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
	
	
	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "blocker"){
			
			
			Destroy(gameObject);
		}
		
		if(col.gameObject.tag == "player"){
			
			
			Debug.Log("hit a player");
			
		}
		
		
		
	}
}
