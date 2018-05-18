using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSelection : MonoBehaviour {
	public GameObject[] solutions;
	private GameObject currentSolution;
	// Use this for initialization
	void Start () {
		currentSolution = solutions [0];
		Debug.Log ("Primera solucion seleccionada");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("1")){
			currentSolution = solutions [0];
			Debug.Log("Primera solucion seleccionada");
		}
		if(Input.GetKey("2")){
			currentSolution = solutions [1];
			Debug.Log("Segunda solucion seleccionada");
		}
		if(Input.GetKey("3")){
			currentSolution = solutions [2];
			Debug.Log("Tercera solucion seleccionada");
		}

	}
}
