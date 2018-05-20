using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCell : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Character"){
			//collider.gameObject.GetComponent<Character>().addArrivedDisabled();
			Debug.Log("Ha llegado un discapacitado");
			collider.gameObject.GetComponent<Character>().setNextCharacterAction(Character.ActionsToDo.arrivedAction);
		}
	}
}
