using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthOrb : MonoBehaviour
{
    public float speed;
	playerMovement pl;

	int x;

    void Start()
    {
        pl= GameObject.Find("player").GetComponent<playerMovement>();
		// x=0;
    }

    // Update is called once per frame
    void Update()
    {
		// x+=1;
        speed = pl.speed;
		
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);

		    

		 
		 
    }
	
	
	
	
	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "blocker"){
			
			
			Destroy(gameObject);
		}
		
		if(col.gameObject.tag == "player"){
			AudioSource scored = GameObject.Find("scoredSound").GetComponent<AudioSource>();
			gameManager gm = GameObject.Find("gameManager").GetComponent<gameManager>();
			GameObject scoreFx = Resources.Load("prefabs/fx/scoreFx") as GameObject;
			Debug.Log("health hit");
			Instantiate(scoreFx,transform.position,transform.rotation);
			Destroy(gameObject);
			gm.OnAddHealth();
			scored.Play();
			
		}
		
		
		
		
		
	}
}
