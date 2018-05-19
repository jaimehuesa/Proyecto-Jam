using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public enum disabilites {blind,alzheimer,wheelchair};
    public disabilites myDisability;
    Vector3 startPosition3D;
    Vector3 destinyPosition3D;
    float moveDistance = 1;
    float moveCharacterTime = 1;
    float moveCharacterTimer = 0;
    bool startMoveCounter = false;
    /*public float speed=1;
    public int xPosInMap=0;
    public int yPosInMap =0;
    // Use this for initialization

    

    GameObject myCell;
    GameObject nextCell;*/

    /*public void setCellInfo(GameObject a_myCell, GameObject a_nextCell)
    {
        a_myCell = myCell;
        a_nextCell = nextCell;
    }*/
    /*  public void setPosIn2DMatrix(int a_xPosInMap,int a_yPosInMap)
      {
          xPosInMap = a_xPosInMap;
          yPosInMap = a_yPosInMap;
      }*/
    /*public void doAction(GameObject a_myCell, GameObject a_nextCell)
    {
        myCell= a_myCell;
        nextCell = a_nextCell;
        startPosition3D = myCell.GetComponent<Cell>().transform.position;
        destinyPosition3D = nextCell.GetComponent<Cell>().transform.position;
        //destinyPosition3D = startPosition3D+ Vector3.forward * moveDistance;
        startMoveCounter = true;
        move();
       
    }*/
    public void doAction()
    {
        startPosition3D = transform.position;
        destinyPosition3D = startPosition3D + Vector3.forward * moveDistance;
        startMoveCounter = true;
    }
    void move()
    {
        if (moveCharacterTimer< moveCharacterTime)
        {
            
            float moveCharacterTimerNormalized = moveCharacterTimer % moveCharacterTime;
            Vector3 vec3Lerp = Vector3.Lerp(startPosition3D, destinyPosition3D, moveCharacterTimer);
            //  float increment =;
            //transform.Translate(Vector3.forward * Time.deltaTime * vec3Lerp.magnitude);
            transform.position=vec3Lerp;
          //  print(vec3Lerp);
        }
        else
        {
            moveCharacterTimer = 0;
            startMoveCounter = false;
        }
        
    }
    void Start () {

        myDisability = disabilites.blind;

    }
	

    
	// Update is called once per frame
	void Update () {
        if (startMoveCounter)
        {
            move();
            moveCharacterTimer += Time.deltaTime;
        }
      
    }
}
