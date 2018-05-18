using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPointToWorld : MonoBehaviour {
	public Camera camara;
	private Ray ray;
	private RaycastHit hitInfo;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			ray = camara.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast(ray, out hitInfo, 100f)){
				if (hitInfo.collider.CompareTag ("Obstacle")) {
					Debug.Log ("Cambiar obstaculo");
				} else {
					Debug.Log ("No puedes hacer nada");
				}
			}

		}
	}
}
