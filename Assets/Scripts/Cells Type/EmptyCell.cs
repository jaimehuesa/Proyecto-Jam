using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCell : Cell {

	void Start(){
		cellType = 0;
		turnTo = -1;
	}
	
	public override bool CanBeOvercome(int dysabledType){
		return true;
	}
}
