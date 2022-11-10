using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGenerator : MonoBehaviour
{
    public GameObject platforms;
	
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
		
	
    }
	
	void OnTriggerEnter(Collider col) {
		float posZ = platforms.transform.position.z + 35f;
		if(col.gameObject.tag == "player"){
			
			
			Debug.Log("end OF THE line");
			platforms.transform.position = new Vector3(0f,0f,posZ);
		}
		
		
		
		
	}
	
	
	
	
}
