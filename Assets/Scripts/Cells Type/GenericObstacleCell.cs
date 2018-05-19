﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObstacleCell : MonoBehaviour {

	public bool isWheelchairObstacle, isBlindObstacle, isAlzheimerObstacle;
	private bool oldWheelchairObs, oldBlindObs, oldAlzheimerObs;
	//public GameObject wc_ObsModel, blind_ObsModel, alz_ObsModel, empty_ObsModel;
	//public GameObject wc_SolModel, blind_SolModel, alz_SolModel;
	//public GameObject modelPlace;
	private int childActive;

	///<summary>
	/// Primero obstaculos despues soluciones. Silla de ruedas, ciego, alzheimer
	///</summary>
	private GameObject[] child = new GameObject[6];
	
	[SerializeField]
	private bool isObstacle;
	private bool preparePenalty = false;
	private bool characterInside = false;
	private bool disableUpdate = false; // No se hacen preguntas

	void Start(){
		isObstacle = true;

		child[0] = this.transform.GetChild(0).gameObject;
		child[1] = this.transform.GetChild(1).gameObject;
		child[2] = this.transform.GetChild(2).gameObject;
		child[3] = this.transform.GetChild(3).gameObject;
		child[4] = this.transform.GetChild(4).gameObject;
		child[5] = this.transform.GetChild(5).gameObject;

		TurnIntoObstacle();	
	}

/*
	void Update(){
		if(!disableUpdate){
			if(isWheelchairObstacle != oldWheelchairObs || isBlindObstacle != oldBlindObs || isAlzheimerObstacle != oldAlzheimerObs){
				PlaceObstacle();
			}
			oldWheelchairObs = isWheelchairObstacle;
			oldBlindObs = isBlindObstacle;
			oldAlzheimerObs = isAlzheimerObstacle;
		}
	}
*/

	public void TurnIntoObstacle(){
		isWheelchairObstacle = false; isBlindObstacle = false; isAlzheimerObstacle = false;

		isObstacle = true;
	
		EnablePrefab(Random.Range(0, 3));
	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Character"){
			characterInside = true;
			Character characterInCell = collider.gameObject.GetComponent<Character>();
			Debug.Log(characterInCell.getMyDisability());
			switch(characterInCell.getMyDisability()){
				case Character.disabilites.wheelchair: 
					if(!CanBeOvercome(1)){
						characterInCell.eliminateCharacter();
					}
					break;
				case Character.disabilites.blind: 
					if(!CanBeOvercome(2)){
						characterInCell.eliminateCharacter();
					}
					break;
				case Character.disabilites.alzheimer:
					if(!CanBeOvercome(3)){
						characterInCell.eliminateCharacter();
					}
					break;
				default: 
					Debug.LogError("The collider character has a disability not included int this script");
					break;
			}
		}
	}

	void OnTriggerExit(Collider collider){
		if(collider.tag == "Character"){
			characterInside = false;
		}
		Debug.Log("EXIT");
		if(preparePenalty){
			preparePenalty = false;
			Debug.Log("TO DO => MULTA");
			//gameManager.Penalty();
		}
		if(!isObstacle){
			TurnIntoObstacle();
		}
	}

	private bool CanBeOvercome(int dysabledType){
		switch(dysabledType){
			case 1: 
				if(isWheelchairObstacle){
					return false;
				}else{
					return true;
				}
			case 2: 
				if (isBlindObstacle){
					return false;
				}else{
					return true;
				}
			case 3: 
				if (isAlzheimerObstacle){
					return false;
				}else{
					return true;				
				}
			default: Debug.LogError("The dysabledType parameter passed is not valid"); return true;
		}
	}

	private void PlaceObstacle(){
		if(isObstacle){
			if(isWheelchairObstacle){
				EnablePrefab(0);
			}else if(isBlindObstacle){
				EnablePrefab(1);
			}else if(isAlzheimerObstacle){
				EnablePrefab(2);
			}
		}		
	}

	public void PlaceSolution(int solution){
		if(isObstacle && !characterInside){
			isObstacle = false;

			switch(solution){
				case 1: EnablePrefab(3); break;
				case 2: EnablePrefab(4); break;
				case 3: EnablePrefab(5); break;
				default: Debug.LogError("Wrong discapacity solution value"); break;
			}
		}		
	}

	private void EnablePrefab(int childNum){
		//Hard reset porq no se
		for(int i = 0 ; i < 6 ; i++){
			child[i].SetActive(false);
		}		

		// esto es por si pones la q no corresponde creo, lo he escrito hace 5 min y no lo tengo claro
		//if(childNum > 2 && childActive + 3 != childNum){
		//	preparePenalty = true;
		//}

		child[childNum].SetActive(true);
		childActive = childNum;

		switch(childActive){
			case 0: isWheelchairObstacle = true; break;
			case 1: isBlindObstacle = true; break;
			case 2: isAlzheimerObstacle = true; break;
			case 3: isWheelchairObstacle = false; break;
			case 4: isBlindObstacle = false; break;
			case 5: isAlzheimerObstacle = false; break;
			default: Debug.LogError("Child out of range"); break;
		}
	}
}
