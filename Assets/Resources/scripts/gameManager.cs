using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gameManager : MonoBehaviour
{
    
	public float score;
	private float hitScore = 10f;
	public Text scoreDisp;
	
	public float life = 3f;
	public string gameType;
	//===============camera area=============
	
	public Camera[] cams;
	public Camera curCam;
	int camCount;
	bool nextCam;
	
	public bool isPause;
	public bool isMute;
	public GameObject gameOverDisp;
	
    void Start()
    {
      cams[1].enabled = false;
	  Time.timeScale = 1;
	  gameOverDisp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisp.text = "Score: " + score + "  life: " + life;
		curCam = cams[camCount];
		
		if(Input.GetKeyDown(KeyCode.C)){
			
			
			OnChangeCamera();
			
		}
		
		if(Input.GetKeyDown(KeyCode.Escape)){
			
			Pause();
			
			
		}
		
    }
	
	
	public void OnScoreNormal(){
		
		score += hitScore;
		
	}
	public void OnLooseScore(float deductScore) {
		
		
		score -= deductScore;
		
	}
	
	public void OnAddHealth(){
		
		if(life < 3f){
		life += 0.5f;
		}
	}
	public void OnGameOver() {
		AudioSource endSound = GameObject.Find("gameOverSound").GetComponent<AudioSource>();
		endSound.Play();
		 gameOverDisp.SetActive(true);
		
	}
	
	public void OnMute() {
		AudioListener au = GameObject.FindObjectOfType<AudioListener>();
		isMute = !isMute;
		
		if(isMute){
			
			au.enabled = false;
			
			
			
		}
			if(!isMute){
			
			au.enabled = true;
			
			
			
		}
		
		
	}
	
	
	
	
	
	
	
	public void OnLifeSystem() {
		playerMovement pm = GameObject.Find("player").GetComponent<playerMovement>();
		
		life -= 0.5f;
		if(life <= 0){
			
			
			pm.enabled= false;
			life = 0;
			StartCoroutine(OnDelay());
			Debug.Log("gameOver");
			
		}
		
	}
	
	IEnumerator OnDelay(){
		
		yield return new WaitForSeconds(2);
		
		Time.timeScale = 0;
		OnGameOver();
		
	}
	
	
	
	public void OnChangeCamera() {
		
		nextCam = !nextCam;
		
		if(nextCam == true){
			
			camCount = 1;
			
			
		}
		
			if(nextCam == false){
			
			camCount = 0;
			
			
		}
		
		foreach(Camera cm in cams){
			
			if(cm != curCam) {
				
				
				cm.enabled = false;
			}else{
				
				
				cm.enabled = true;
			}
			
			
		}
		
		
		
	}
	
	
	public void Pause(){
		
		
		isPause = !isPause;
		
		if(isPause){
			
			Time.timeScale = 0;
			
			
		}
			if(!isPause){
			
			Time.timeScale = 1;
			
			
		}
		
		
	}
	
	
	public void OnReset() {
		
		Scene sne = SceneManager.GetActiveScene();
		
		SceneManager.LoadScene(sne.name);
		
		
		
	}
	
	public void OnHome(){
		
		SceneManager.LoadScene("menu");
		
	}
	
	
	
	
	
	
	
	
	
	
	
	
}
