using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
	
	public GameObject selectGameOp;
    public GameObject howTo;
	public bool isClick;
    void Start()
    {
        selectGameOp.SetActive(false);
		howTo.SetActive(false);
    }


    void Update()
    {
        
    }
	
	
	
	public void OnStartGame(){
		
		selectGameOp.SetActive(true);
		
		
	}
	
	public void SelectGame(string sceneName){
		
		SceneManager.LoadScene(sceneName);
		
		
	}
	public void Quit() {
		
		Debug.Log("quiting game");
		Application.Quit();
		
		
	}
	public void OnHowTo() {
		
		isClick = !isClick;
		
		if(isClick){
		howTo.SetActive(true);
		}
			if(!isClick){
		howTo.SetActive(false);
		}
		
	}
	
	
	
	
	
	
}
