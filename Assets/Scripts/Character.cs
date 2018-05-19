using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum disabilites { blind, alzheimer, wheelchair };
    enum actionsToDo { moveAction, rotationAction, disappear };
    actionsToDo myCurrentAction = actionsToDo.moveAction; // por defecto va a moverse
    disabilites myDisability;
    Vector3 startPosition3D;
    Vector3 destinyPosition3D;
    float moveDistance = 1;
    float moveCharacterTime = 1;
    float moveCharacterTimer = 0;
    bool startMoveCounter = false;

    float rotateYValue = -90;

    GameObject myCell;
    GameObject nextCell;
    void Start()
    {
        myDisability = disabilites.blind;
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
                case actionsToDo.moveAction:
                    move(); break;
                case actionsToDo.rotationAction: rotate();  break;
            }
            moveCharacterTimer += Time.deltaTime;
        }

    }
    public void doAction()
    {
        switch (myCurrentAction)
        {
            case actionsToDo.moveAction:
                startPosition3D = transform.position;
                destinyPosition3D = startPosition3D + Vector3.forward * moveDistance;
                startMoveCounter = true;
                break;
        }

    }
    void move()
    {
        if (moveCharacterTimer < moveCharacterTime)
        {
            float moveCharacterTimerNormalized = moveCharacterTimer % moveCharacterTime;
            Vector3 vec3Lerp = Vector3.Lerp(startPosition3D, destinyPosition3D, moveCharacterTimer);
            transform.position = vec3Lerp;
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
            Transform toRotation= transform;
            toRotation.Rotate(Vector3.up * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, rotateCharacterTimerNormalized);
           // transform.position = vec3Lerp;
        }
        else
        {
            moveCharacterTimer = 0;
            startMoveCounter = false;
        }
    }
}
