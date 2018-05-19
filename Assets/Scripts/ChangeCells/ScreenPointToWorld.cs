using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPointToWorld : MonoBehaviour {
	public Camera camara;
	private Ray ray;
	private RaycastHit hitInfo;
	private ResourceSelection resourceSelection;
	private GameObject obstacleCell;

	// Use this for initialization
	void Start () {
		resourceSelection = GetComponent<ResourceSelection> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			ray = camara.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast(ray, out hitInfo, 100f)){
				if (hitInfo.collider.CompareTag ("Obstacle")) {
					obstacleCell = hitInfo.collider.gameObject;
					ChangeCellSolution (obstacleCell.transform);
					Destroy (obstacleCell);
					Debug.Log ("Cambiar obstaculo");
				} else {
					Debug.Log ("No puedes hacer nada");
				}
			}

		}
	}

	void ChangeCellSolution(Transform transf){
		Instantiate (resourceSelection.currentSolution, transf.position, transf.rotation);
		
	}

}
