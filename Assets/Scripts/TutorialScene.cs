using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScene : MonoBehaviour {

	private bool firstScene = true;
	public Sprite secondImage;
	public Image imagePosition;

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			if(!firstScene){
				SceneManager.LoadScene("Main");
			}else{
				imagePosition.sprite = secondImage;
				firstScene = false;
			}			
		}
	}
}
