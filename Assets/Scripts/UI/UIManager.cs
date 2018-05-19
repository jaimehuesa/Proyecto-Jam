using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnableUIObject(GameObject go){
		go.SetActive (true);
	}

	public void DisableUIObject(GameObject go){
		go.SetActive (false);
	}

}
