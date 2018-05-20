using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Return)) {
			Debug.Log ("He presionado Enter");
			Application.LoadLevel ("Main");
		}
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel("StartGame");
		}
	}
}
