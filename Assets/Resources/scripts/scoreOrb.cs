using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreOrb : MonoBehaviour
{
    MeshRenderer rend;
	public Color[] colorList;
	public Color curColor;
	public int colorCount;
	playerMovement pl;
	public string[] colorListName;
	public string curName;
	public float speed;
	
	 public Mesh[] meshList;
	 public Mesh curMesh;
	 public int meshCount;
	
    void Start()
    {
		colorCount = Random.Range(0,3);
		curColor = colorList[colorCount];
		
		curName = colorListName[colorCount];
		
        rend = GetComponent<MeshRenderer>();
		rend.material.color = curColor;
		pl= GameObject.Find("player").GetComponent<playerMovement>();
		meshCount = Random.Range(0,3);
		
    }

    // Update is called once per frame
    void Update()
    {
		
		MeshFilter mf = GetComponent<MeshFilter>();
		curMesh = meshList[meshCount];
		
		
		mf.mesh = curMesh;
		
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
