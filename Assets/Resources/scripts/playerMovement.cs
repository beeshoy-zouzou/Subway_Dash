using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
   public float  speed;
   public bool isSwitch;
   
   
   MeshRenderer rend;
   float seconds = 0f;
   public Color[] colorList;
   Color curColor;
   public int playerColorCount;
   

	public string[] colorName;
	public string curColorName;

	public float ClickDuration = 2;
    //public UnityEvent OnLongClick;

    bool clicking = false;
    float totalDownTime = 0;
	
   
    void Start()
    {
       
		rend =GetComponent<MeshRenderer>();


    }



    // Update is called once per frame
    void Update()
    {
		
			
		speed += 0.2f *Time.deltaTime;
		
	 
		// transform the position
		// if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     totalDownTime = 0;
        //     clicking = true;
        // }

        // If a first click detected, and still clicking,
        // measure the total click time, and fire an event
        // if we exceed the duration specified
        // if (clicking && Input.GetKeyDown(KeyCode.Space))
        // {
        //     totalDownTime += Time.deltaTime;

        //     if (totalDownTime >= ClickDuration)
        //     {
        //         Debug.Log("Long click");
        //         clicking = false;
        //         //OnLongClick.Invoke();
        //     }
        // }

        // If a first click detected, and we release before the
        // duraction, do nothing, just cancel the click
        // if (clicking && Input.GetKeyDown(KeyCode.Space))
        // {
        //     clicking = !clicking;
        // }

		float posY = 0.822f;
		Vector3 posUp = new Vector3(transform.localPosition.x,4.9f,transform.localPosition.z);
		Vector3 posDown = new Vector3(transform.localPosition.x,0.822f,transform.localPosition.z);
		
		// translate Horizontal
		
			
		transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * 15f * Time.deltaTime,0f,0f));
		// if(Input.GetKey(KeyCode.Space)){
			
		// 	transform.position= new Vector3(Random.value,Random.value,Random.value); 
			

			
		// }
		

		transform.position = new Vector3(Mathf.Clamp(transform.position.x,-2.3f,2.3f),Mathf.Clamp(transform.position.y,0.822f,4.9f),transform.position.z);	


 
			

			
		
		
		
		
		#if(UNITY_ANDROID)
			
		transform.Translate(new Vector3(Input.acceleration.x,0f,0f));
		
		#endif
		
		
		OnSwitchPlatform();
		
		// switch position
		if(isSwitch){
			
			
			transform.position = Vector3.Slerp(transform.position,posUp,10f * Time.deltaTime);
			
			
			
		}else {
			
			
			transform.position = Vector3.Slerp(transform.position,posDown,10f * Time.deltaTime);
			
			
		}
		
		
		OnChangeColor(5f);
		
		
		
    }
	
	// swich platform
	void OnSwitchPlatform(){
		
		
		
		if(Input.GetKeyDown(KeyCode.Space)){
			
			
			isSwitch = !isSwitch;

			
		}
		
		
	}
	// switch button
	public void OnButtonSwitch() {
		
		isSwitch = !isSwitch;
		
	}
	
	// switch color
	void OnChangeColor(float resetSeconds) {
		
		seconds -= Time.deltaTime;
		
	
		
		
		
		if(seconds <= 0){
			
			curColor = colorList[playerColorCount];
		curColorName = colorName[playerColorCount];
			
			
			playerColorCount = Random.Range(0,3);
			seconds = resetSeconds;
			rend.material.color = curColor;
			
		}
		
	}
	
	
	void OnTriggerEnter(Collider col){
		
		scoreOrb so = col.gameObject.GetComponent<scoreOrb>();
		




		gameManager gm = GameObject.Find("gameManager").GetComponent<gameManager>();
		AudioSource hit = GameObject.Find("hitWall").GetComponent<AudioSource>();
		AudioSource scored = GameObject.Find("scoredSound").GetComponent<AudioSource>();
		
		
		if(col.gameObject.tag == "scoreOrb" &&  curColorName == so.curName ){
			
			if(gm.gameType == "normal"){
			GameObject scoreFx = Resources.Load("prefabs/fx/scoreFx") as GameObject;
			Debug.Log("scored!");
			Instantiate(scoreFx,col.transform.position,transform.rotation);
			Destroy(col.gameObject);
			// return back

			
			gm.OnScoreNormal();
			scored.Play();
			}
			
			if(gm.gameType == "flipped"){
				
				
			GameObject scoreFx = Resources.Load("prefabs/fx/blockerHitFx") as GameObject;
			Debug.Log("wrong");
			Instantiate(scoreFx,col.transform.position,transform.rotation);
			Destroy(col.gameObject);
			gm.OnLooseScore(2.5f);
			hit.Play();
				
				
			}
			
		}
		
		if(col.gameObject.tag == "scoreOrb" &&  curColorName != so.curName){
			
			if(gm.gameType == "flipped"){
			GameObject scoreFx = Resources.Load("prefabs/fx/scoreFx") as GameObject;
			Debug.Log("scored!");
			Instantiate(scoreFx,col.transform.position,transform.rotation);
			Destroy(col.gameObject);
			gm.OnScoreNormal();
			scored.Play();
			}
			
			if(gm.gameType == "normal"){
			GameObject scoreFx = Resources.Load("prefabs/fx/blockerHitFx") as GameObject;
			Debug.Log("wrong");
			Instantiate(scoreFx,col.transform.position,transform.rotation);
			Destroy(col.gameObject);
			gm.OnLooseScore(2.5f);
			hit.Play();
			}
		}
		
		if(col.gameObject.tag == "obstacle"){
			GameObject blockerFx = Resources.Load("prefabs/fx/blockerHitFx") as GameObject;
			Destroy(col.gameObject);

			Instantiate(blockerFx,col.transform.position,transform.rotation);
			gm.OnLifeSystem();
			hit.Play();
			
			
		}
		
		
		
		
		
		
		
	}
	
	
	
		
		
}
	
	

