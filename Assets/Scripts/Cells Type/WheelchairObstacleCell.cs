using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelchairObstacleCell : Cell {

	// Use this for initialization
	void Start () {
		cellType = 2;
		turnTo = -1;
	}
	
	public override bool CanBeOvercome(int dysabledType){
		if(dysabledType == 1){
			return false;
		}else{
			return true;
		}
	}
}
