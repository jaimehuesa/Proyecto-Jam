using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerCellRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider c){
		if (c.CompareTag ("Character")) {
			Debug.Log ("Rota el Character");
			c.GetComponent<Character> ().callRotateFromCell (90f);
		}
	}
}
