using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainController : MonoBehaviour
{
    public GameObject characterPrefab;
    public GameObject cellPrefab;
    public GameObject spawnerGameObject;
    public GameObject[] modelPrefabs3D;
    // parents no hace falta que sean prefabs ya que genera algo de tipo empty

    public float cellSize = 1;
    int numCharactersSaved = 0;
    GameObject mapInstantiationParent; // to store the map tiles here
    GameObject characterInstantiationParent; // to store the characters here
    List<GameObject> characters;
    int xColumns = 5; /// num columns
    int yRows = 5;  // num rows
    int ticks = 0;
    int ticksToCreate = 2;
    //float createCharacterTime = 4;
    float createCharacterTimer = 0;

    float offsetHeightSpawner = 0.1f;
    float doActionTime = 2;
    float doActionTimer = 0;

    float charactersInDestiny = 0;
    float charactersEliminated = 0;



    // podemos hacer una matriz ya que en ningun momento va a haber 2 characters en una misma casilla


    void Start()
    {

        characterInstantiationParent = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);

        characterInstantiationParent.name = "Characters";
        characters = new List<GameObject>();
        //createMap();
        //spawnerGameObject = Instantiate(cellPrefab,
            //new Vector3(2, 0, 0), Quaternion.identity);
        // createCharacterTimer = createCharacterTime; // para que no tarde el tiempo maximo en instanciarlo

     
    }
    
   


    void createCharacter()
    {
        characterInstantiationParent = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
        characterInstantiationParent.name = "Characters";
        Vector3 positionSpawner = spawnerGameObject.transform.position;
        GameObject createdCharacter = Instantiate(characterPrefab,
            new Vector3(positionSpawner.x, positionSpawner.y + offsetHeightSpawner, positionSpawner.z), Quaternion.identity);
        Character characterScript = createdCharacter.GetComponent<Character>();

        GameObject created3dModel = instantiateRandom3DModel(createdCharacter);
        characterScript.my3DModel = created3dModel;
        characterScript.setMyAnimator();
        characterScript.setGameObjectController(this.gameObject);
        createdCharacter.transform.SetParent(characterInstantiationParent.transform, false);
        characters.Add(createdCharacter);

    }
    GameObject instantiateRandom3DModel(GameObject characterGameObject)
    {
        // characterInstantiationParent.name = "Character";
        int length = modelPrefabs3D.Length;
        int rand = Random.Range(0, length);
        GameObject created3dModel = Instantiate(modelPrefabs3D[rand], new Vector3(0, 0, 0), Quaternion.identity);
        created3dModel.transform.SetParent(characterGameObject.transform, false);
        //created3dModel.transform.Rotate(Vector3.up * -90, Space.World);
        return created3dModel;
        //print(length);
    }
    void createMap()
    {
        mapInstantiationParent = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
        mapInstantiationParent.name = "Map";
        float cellPosY = 0;
        for (int r = 0; r < xColumns; r++)
        {
            float cellPosX = 0;
            for (int c = 0; c < yRows; c++)
            {
                cellPosX += cellSize;
                GameObject createdCellObject = Instantiate(cellPrefab, new Vector3(cellPosX, 0, cellPosY), Quaternion.identity);
                createdCellObject.transform.SetParent(mapInstantiationParent.transform, false);
            }
            cellPosY += cellSize;
        }

    }
    void showDisabilities()
    {
        foreach (GameObject guy in characters)
        {
            Character character = guy.GetComponent<Character>();
            print(character.getMyDisability());
        }
    }
    void callToAction()
    {
        //showDisabilities();
        //foreach (GameObject guy in characters)
        for (int i = 0; i < characters.Count; i++)
        {
            GameObject guy = characters[i];
            Character character = guy.GetComponent<Character>();
            character.doAction();
        }
        ticks++;
        if (ticks % ticksToCreate == 0)
        {
            createCharacter();
        }

    }
    public void characterSaved()
    {
        numCharactersSaved++;
    }
    public void increaseScore()
    {
        charactersInDestiny++;
    }
    public void decreaseScore()
    {
        charactersEliminated++;
    }
    public void removeCharacterFromList(GameObject characterGameObject)
    {
        //print(characters.Count);
        characters.Remove(characterGameObject);
        charactersEliminated++;
        //print(characters.Count);

    }
    // Update is called once per frame
    void Update()
    {
        //createCharacterTimer += Time.deltaTime;
        /*if (createCharacterTimer > createCharacterTime)
        {
            createCharacter();
            createCharacterTimer = 0;
        }*/
        if (doActionTimer > doActionTime)
        {
            doActionTimer = 0;
            callToAction();
        }
        doActionTimer += Time.deltaTime;
    }
}

