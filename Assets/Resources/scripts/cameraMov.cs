using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMov : MonoBehaviour
{
     public Transform target;
	 Vector3 cameraOffset;
	 public float speed;
	 playerMovement pl;
	 
	 
    void Start()
    {
        cameraOffset = transform.position - target.transform.position;
		pl= GameObject.Find("player").GetComponent<playerMovement>();
		
	}
    

    // Update is called once per frame
    void Update()
    {
		Vector3 targetLook = target.position - transform.position;
		Quaternion rot = Quaternion.LookRotation(targetLook);
		
		
	float forwardPos = target.transform.position.z - 4f;
		
        Vector3 pos = target.position + cameraOffset;
		
		if(pl.isSwitch == false){
		transform.position = new Vector3(transform.position.x,2f,forwardPos);
		}
		
		if(pl.isSwitch == true){
		transform.position = new Vector3(transform.position.x,3.9f,forwardPos);
		}
		
		transform.rotation = Quaternion.Slerp(transform.rotation,rot, 10f *Time.deltaTime);
		
	
		
		
    }

	
	
	
	
	
}
