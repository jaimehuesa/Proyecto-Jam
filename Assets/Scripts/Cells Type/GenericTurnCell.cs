using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTurnCell : MonoBehaviour {

	private bool leftTurn;

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Character"){
			if(leftTurn){
				//Enviar mensaje izquierda
			}else{
				//Enviar mensaje derecha
			}
		}
	}

}
