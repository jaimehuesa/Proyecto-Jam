using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSelection : MonoBehaviour {
	public GameObject[] solutions;

	public GameObject solution1UI;
	public GameObject solution2UI;
	public GameObject solution3UI;

	[HideInInspector]
	public GameObject currentSolution;
	// 1 wheelChair, 2 blind, 3 alzheimer
	public int currentIntSolution;
	private GameObject currentSolutionUI;

	// Use this for initialization
	void Start () {
		currentSolution = solutions [0];
		solution1UI.SetActive (true);
		currentSolutionUI = solution1UI;
		Debug.Log ("Primera solucion seleccionada");
		currentIntSolution = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("1")){
			currentSolution = solutions [0];
			currentSolutionUI.SetActive (false);
			solution1UI.SetActive (true);
			currentSolutionUI = solution1UI;
			Debug.Log("Primera solucion seleccionada");
			currentIntSolution = 1;
		}
		if(Input.GetKey("2")){
			currentSolution = solutions [1];
			currentSolutionUI.SetActive (false);
			solution2UI.SetActive (true);
			currentSolutionUI = solution2UI;
			Debug.Log("Segunda solucion seleccionada");
			currentIntSolution = 2;
		}
		if(Input.GetKey("3")){
			currentSolution = solutions [2];
			currentSolutionUI.SetActive (false);
			solution3UI.SetActive (true);
			currentSolutionUI = solution3UI;
			Debug.Log("Tercera solucion seleccionada");
			currentIntSolution = 3;
		}

	}
}
