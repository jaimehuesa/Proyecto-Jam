﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*        // how to call from tiles to do the diferent actions in the next turn
          characterScript.setTheNextActionToDo(Character.ActionsToDo.moveAction);*/


public class Character : MonoBehaviour
{
    public enum disabilites { blind, alzheimer, wheelchair };
    public GameObject destructionObjectPrefabObjectPrefab;
    public enum ActionsToDo { moveAction, rotationAction, eliminatedAction, victoryAction };

    GameMainController gameMainController;
    ActionsToDo myCurrentAction = ActionsToDo.moveAction; // por defecto va a moverse
    disabilites myDisability;
    Vector3 startPosition;
    Vector3 destinyPosition;
    Quaternion startRotation;
    Quaternion destinyRotation;

    Animator myAnimator;

    float moveDistance = 1;
    float moveCharacterTime = 1;
    float moveCharacterTimer = 0;
    bool startMoveCounter = false;

    float rotateYValue = -90;

    GameObject myCell;
    GameObject nextCell;

    public GameObject my3DModel;
    void Start()
    {
        myDisability = disabilites.blind;
     
    }
    public void setMyAnimator()
    {
        myAnimator = my3DModel.GetComponent<Animator>();
    }
    public void setTheNextActionToDo(ActionsToDo a_action)
    {
        myCurrentAction = a_action;
    }
    public void setGameObjectController(GameObject gameObject)
    {
        gameMainController = gameObject.GetComponent<GameMainController>();
    }
    public disabilites getMyDisability()
    {
        return myDisability;
    }
    // Update is called once per frame
    void Update()
    {
        if (startMoveCounter)
        {
            switch (myCurrentAction)
            {
                case ActionsToDo.moveAction:
                    move(); break;
                case ActionsToDo.rotationAction: rotate();  break;
            }
            moveCharacterTimer += Time.deltaTime;
        }

    }
    
    private disabilites RandomDisabilites()
    {
        return (disabilites)(UnityEngine.Random.Range(0, disabilites.GetNames(typeof(disabilites)).Length));
    }

    private ActionsToDo randomAction()
    {
        return (ActionsToDo)(UnityEngine.Random.Range(0, ActionsToDo.GetNames(typeof(ActionsToDo)).Length));

    }
    //int i = 0;
    public void doAction()
    {
        myCurrentAction = randomAction();
        //print(myCurrentAction);
        // myCurrentAction = (ActionsToDo)0;
        myCurrentAction = ActionsToDo.moveAction;
        startPosition = this.transform.position;
        destinyPosition = this.transform.position;
        startRotation = this.transform.rotation;
        destinyRotation =transform.rotation;
        Vector3 pos = this.transform.position;
        Quaternion rotation = this.transform.rotation;
        switch (myCurrentAction)
        {
            case ActionsToDo.moveAction:
                destinyPosition = startPosition + transform.forward * moveDistance;
                startMoveCounter = true;
                break;
            case ActionsToDo.rotationAction:
                //destinyTransformation.Rotate(Vector3.up * rotateYValue, Space.World);
                destinyRotation*= Quaternion.Euler(0, rotateYValue, 0);
                startMoveCounter = true;
                break;
            case    ActionsToDo.eliminatedAction:
                eliminateCharacter(); break;
        }
      //  print(startTransformation.position + ", " + destinyTransformation.position);
    }
    void move()
    {
        
        if (moveCharacterTimer < moveCharacterTime)
        {
            myAnimator.SetTrigger("Andar");
            float moveCharacterTimerNormalized = moveCharacterTimer % moveCharacterTime;
            //print(moveCharacterTimerNormalized);
            Vector3 vec3Lerp = Vector3.Lerp(startPosition, destinyPosition, moveCharacterTimerNormalized);
            transform.position = vec3Lerp;
            
            //transform.position += Vector3.forward * Time.deltaTime;

        }
        else
        {
            moveCharacterTimer = 0;
            startMoveCounter = false;
        }
    }
    void rotate()
    {
        if (moveCharacterTimer < moveCharacterTime)
        {
            float rotateCharacterTimerNormalized = moveCharacterTimer % moveCharacterTime;
           // print(transform.rotation);
            transform.rotation = Quaternion.Lerp(startRotation, destinyRotation, rotateCharacterTimerNormalized);
           // transform.Rotate(Vector3.up* Time.deltaTime, Space.World);
            //Quaternion.Euler(0, rotateYValue, 0);
            // transform.position = vec3Lerp;
        }
        else
        {
            //transform.Rotate(Vector3.up* 90, Space.World);
            moveCharacterTimer = 0;
            startMoveCounter = false;
        }
    }
    void eliminateCharacter()
    {
        Instantiate(destructionObjectPrefabObjectPrefab,transform.position,Quaternion.identity);
        gameMainController.removeCharacterFromList(this.gameObject);
        Destroy(this.gameObject);
    }
    void characterArrivedDestiny()
    {

    }
}
