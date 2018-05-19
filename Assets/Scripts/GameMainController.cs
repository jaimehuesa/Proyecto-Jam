using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainController : MonoBehaviour
{
    public GameObject characterPrefab;
    public GameObject cellPrefab;
    public GameObject mapPrefab;
    //vec2Int spawnerlCellMatrixPos;

    public GameObject mapInstantiationParent; // to store the map tiles here
    GameObject spawnCell;
    Vector2 spawnCellPosition3D; // se puede sacar a partir de la 2d, si se tiene una variable que sea el tamaño de cada casilla
    Vector2 spawnCellPosition2DMatrix = new Vector2(3, 2);
    List<GameObject> characters;
    int xColumns = 5; /// num columns
    int yRows = 5;  // num rows
    float createCharacterTime = 4;
    float createCharacterTimer = 0;

    float doActionTime = 2;
    float doActionTimer = 0;

    float cellSize = 1;
    float instantiationHeightCharacter = 0.6f;
    GameObject[,] map;
    // podemos hacer una matriz ya que en ningun momento va a haber 2 characters en una misma casilla
    GameObject[,] charactersMapPosition;

    //GameObject cell;
    //Cell[,] map = new Cell[height, width];

    // Use this for initialization

    void Start()
    {
        characters = new List<GameObject>();
        map = new GameObject[yRows, xColumns];
        createMap();
       
        spawnCell = Instantiate(cellPrefab,
            new Vector3(2,0,0), Quaternion.identity);
        createCharacterTimer = createCharacterTime; // para que no tarde el tiempo maximo en instanciarlo
    }
    void createCharacter()
    {
        /*
        //print(spawnCellPosition2DMatrix);
        Cell cellScript = spawnCell.GetComponent<Cell>();
        GameObject createdCharacter = Instantiate(characterPrefab, 
            new Vector3(spawnCell.transform.position.x, spawnCell.transform.position.y+cellScript.characterPosYCell, spawnCell.transform.position.z), Quaternion.identity);
        Character characterScript=createdCharacter.GetComponent<Character>();
        characters.Add(createdCharacter);
        */
        Cell cellScript = spawnCell.GetComponent<Cell>();
        GameObject createdCharacter = Instantiate(characterPrefab,
            new Vector3(spawnCell.transform.position.x, spawnCell.transform.position.y + cellScript.characterPosYCell, spawnCell.transform.position.z), Quaternion.identity);
        Character characterScript = createdCharacter.GetComponent<Character>();
        characters.Add(createdCharacter);
    }
    void createMap()
    {
        /*mapInstantiationParent = Instantiate(mapPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        float cellPosY = 0;
        for (int r = 0; r < xColumns; r++)
        {
            float cellPosX = 0;
            for (int c = 0; c < yRows; c++)
            {
                cellPosX += cellSize;
                GameObject createdCellObject = Instantiate(cellPrefab, new Vector3(cellPosX, 0, cellPosY), Quaternion.identity);
                createdCellObject.transform.SetParent(mapInstantiationParent.transform, false);
                Cell cellScript = createdCellObject.GetComponent<Cell>();
                // print("hola");
                cellScript.setPos2DMatrix(r,c);
                //cellScript.position = new Vec3(r.xPos,0 ,c);
                 map[r, c] = createdCellObject;
            }
            cellPosY += cellSize;
        }
        */
        mapInstantiationParent = Instantiate(mapPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        float cellPosY = 0;
        for (int r = 0; r < xColumns; r++)
        {
            float cellPosX = 0;
            for (int c = 0; c < yRows; c++)
            {
                cellPosX += cellSize;
                GameObject createdCellObject = Instantiate(cellPrefab, new Vector3(cellPosX, 0, cellPosY), Quaternion.identity);
                createdCellObject.transform.SetParent(mapInstantiationParent.transform, false);
                map[r, c] = createdCellObject;
            }
            cellPosY += cellSize;
        }

    }
    void showDisabilities()
    {
        foreach (GameObject guy in characters)
        {
            Character character = guy.GetComponent<Character>();
            print(character.myDisability);
        }
    }
    void callToAction()
    {
        /* foreach (GameObject guy in characters)
         {
             Character character = guy.GetComponent<Character>();
             GameObject characterCell = map[character.xPosInMap, character.yPosInMap];
             int nextCellIncrementX= characterCell.GetComponent<Cell>().xDirection;
             int nextCellIncrementY = characterCell.GetComponent<Cell>().yDirection;
             int nextCellPosX = character.xPosInMap + nextCellIncrementX;
             int nextCellPosY = character.yPosInMap + nextCellIncrementY;
             if (nextCellPosX>=xColumns|| nextCellPosY >= yRows){
                 Debug.Log("Error! the next cell is outside boundaries");
             }
             GameObject characterNextCell = map[nextCellPosX, nextCellPosY];
             print("Going from "+ character.xPosInMap+", "+ character.yPosInMap+
                 " to "+nextCellPosX + ", " + nextCellPosY);

             character.doAction(characterCell, characterNextCell);
         }*/

        foreach (GameObject guy in characters)
        {
            Character character = guy.GetComponent<Character>();
            character.doAction();
        }

    }
    // Update is called once per frame
    void Update()
    {
        createCharacterTimer += Time.deltaTime;
        if (createCharacterTimer > createCharacterTime)
        {
            createCharacter();
            createCharacterTimer = 0;
        }
        if (doActionTimer > doActionTime)
        {
            doActionTimer = 0;
            callToAction();
        }

        doActionTimer += Time.deltaTime;




    }
}

