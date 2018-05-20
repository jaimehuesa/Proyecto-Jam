using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObstacleCell : MonoBehaviour {

	[SerializeField]
	private bool isWheelchairObstacle, isBlindObstacle, isAlzheimerObstacle;
	private bool oldWheelchairObs, oldBlindObs, oldAlzheimerObs;
	//public GameObject wc_ObsModel, blind_ObsModel, alz_ObsModel, empty_ObsModel;
	//public GameObject wc_SolModel, blind_SolModel, alz_SolModel;
	//public GameObject modelPlace;
	private int childActive;
	private int lastObstacleActive;

	///<summary>
	/// Primero obstaculos despues soluciones. Silla de ruedas, ciego, alzheimer
	///</summary>
	private GameObject[] child = new GameObject[6];
	
	[SerializeField]
	private bool isObstacle;
	[SerializeField]
	private bool characterInside = false;

	void Start(){
		isObstacle = true;

		child[0] = this.transform.GetChild(0).gameObject;
		child[1] = this.transform.GetChild(1).gameObject;
		child[2] = this.transform.GetChild(2).gameObject;
		child[3] = this.transform.GetChild(3).gameObject;
		child[4] = this.transform.GetChild(4).gameObject;
		child[5] = this.transform.GetChild(5).gameObject;

		//childActive = Random.Range(0, 3);
		//EnablePrefab(childActive);
		TurnIntoObstacle();		
	}

	/*
	void Update(){
		if(isWheelchairObstacle != oldWheelchairObs || isBlindObstacle != oldBlindObs || isAlzheimerObstacle != oldAlzheimerObs){
			PlaceObstacle();
		}
		oldWheelchairObs = isWheelchairObstacle;
		oldBlindObs = isBlindObstacle;
		oldAlzheimerObs = isAlzheimerObstacle;
	}
	*/

	public void TurnIntoObstacle(){
		isObstacle = true;

		int randomNum = Random.Range(0, 3);
		lastObstacleActive = randomNum;
		EnablePrefab(randomNum);
	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Character"){
			characterInside = true;
			Character characterInCell = collider.gameObject.GetComponent<Character>();
			Debug.Log(characterInCell.getMyDisability());
			switch(characterInCell.getMyDisability()){
				case Character.disabilites.wheelchair: 
					if(!CanBeOvercome(0, characterInCell)){
						if(isObstacle){
							characterInCell.eliminateCharacter();
							characterInside = false;
						}else{
							characterInCell.addPenalty();
						}
					}else{
						if(!isObstacle && lastObstacleActive != 0){
							characterInCell.addPenalty();
						}
					}
					break;
				case Character.disabilites.blind: 
					if(!CanBeOvercome(1, characterInCell)){
						if(isObstacle){
							characterInCell.eliminateCharacter();
							characterInside = false;
						}else{
							characterInCell.addPenalty();
						}
					}else{
						if(!isObstacle  && lastObstacleActive != 1){
							characterInCell.addPenalty();
						}
					}
					break;
				case Character.disabilites.alzheimer:
					if(!CanBeOvercome(2, characterInCell)){
						if(isObstacle){
							characterInCell.eliminateCharacter();
							characterInside = false;
						}else{
							characterInCell.addPenalty();
						}
					}else{
						if(!isObstacle  && lastObstacleActive != 2){
							characterInCell.addPenalty();
						}
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
			Debug.Log("EXIT");
			if(!isObstacle){
				TurnIntoObstacle();
			}
		}
	}

	private bool CanBeOvercome(int dysabledType, Character character){
		switch(dysabledType){
			case 0: 
				if(isWheelchairObstacle){
					return false;
				}else{
					if(!isObstacle && (isWheelchairObstacle || isBlindObstacle || isAlzheimerObstacle)){
						//character.addPenalty();
					}
					return true;
				}
			case 1: 
				if (isBlindObstacle){
					return false;
				}else{
					if(!isObstacle && (isWheelchairObstacle || isBlindObstacle || isAlzheimerObstacle)){
						//character.addPenalty();
					}
					return true;
				}
			case 2: 
				if (isAlzheimerObstacle){
					return false;
				}else{
					if(!isObstacle && (isWheelchairObstacle || isBlindObstacle || isAlzheimerObstacle)){
						//character.addPenalty();
					}
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
		if(!characterInside){
			if(isObstacle){
				isObstacle = false;

				switch(solution){
					case 1: EnablePrefab(3); break;
					case 2: EnablePrefab(4); break;
					case 3: EnablePrefab(5); break;
					default: Debug.LogError("Wrong discapacity solution value"); break;
				}
			}	
		}	
	}

	private void EnablePrefab(int childNum){
		child[childActive].SetActive(false);

		child[childNum].SetActive(true);
		childActive = childNum;

		switch(childActive){
			case 0: isWheelchairObstacle = true; isBlindObstacle = false; isAlzheimerObstacle = false; break;
			case 1: isWheelchairObstacle = false; isBlindObstacle = true; isAlzheimerObstacle = false; break;
			case 2: isWheelchairObstacle = false; isBlindObstacle = false; isAlzheimerObstacle = true; break;
			case 3: isWheelchairObstacle = false; break;
			case 4: isBlindObstacle = false; break;
			case 5: isAlzheimerObstacle = false; break;
			default: Debug.LogError("Child out of range"); break;
		}
	}
}
