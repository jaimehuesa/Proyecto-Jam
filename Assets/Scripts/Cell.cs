using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cell : MonoBehaviour {

    public float characterPosYCell = 0.6f;

    /// <summary>
	/// 0 if the cell has no functionality,
	/// 1 if is a turn cell and 2 if is an obstacle
	/// </summary>
	protected int cellType;
	/// <summary>
	/// -1 if is not a turn cell
	/// 0 for left turn,
	/// 1 for right turn
	/// </summary>
	protected int turnTo;

	public void ReplaceCell(GameObject newCell){
		Instantiate(newCell, this.transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}

	/// <summary>
	/// Returns 0 if the cell has no functionality,
	/// 1 if is a turn cell and 2 if is an obstacle
	/// </summary>
	public int GetCellType(){
		return cellType;
	}

	/// <summary>
	/// Returns true if the disabled person type can overcome this cell
    /// else returns false
	/// </summary>
	/// <param name="disabledType"> Disability type -> 1 WheelChair, 2 Blind, 3 Alzheimer.</param>
	public abstract bool CanBeOvercome(int disabledType);

	/// <summary>
	/// Returns true if the disabled person has to turn left
    /// else returns false (right turn)
	/// </summary>
	public bool HasToTurnLeft(){
		if(turnTo == -1){
			Debug.LogError("This is not a turn cell!");
			return true;
		}else if(turnTo == 0){
			return true;
		}else{
			return false;
		}
	}
}
