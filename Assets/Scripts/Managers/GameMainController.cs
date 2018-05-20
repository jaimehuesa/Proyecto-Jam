using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //include this to use the SceneManager
public class GameMainController : MonoBehaviour
{
    public GameObject characterPrefab;
    public GameObject cellPrefab;
    public GameObject spawnerGameObject;
    public GameObject[] modelPrefabs3D;
    public GameObject HUDManagerGameObject;
    public GameObject soundManagerGameObject;

    // parents no hace falta que sean prefabs ya que genera algo de tipo empty

    //score things to change
    const int initialHP = 3;
    const int initialDisabledArrived = 0;
    const float initialPenalization = 0;

    int HP = initialHP;
    int disabledArrived = initialDisabledArrived;
    float penalization = initialPenalization;
    float endScore = 0;

    SoundManager soundManager;
    HUDManager hudmanager;
    public float cellSize = 1;
    int numCharactersSaved = 0;
    GameObject mapInstantiationParent; // to store the map tiles here
    GameObject characterInstantiationParent; // to store the characters here
    List<GameObject> characters;
    int xColumns = 5; /// num columns
    int yRows = 5;  // num rows
    int ticks = 0;
    int ticksToCreate = 20;
    //float createCharacterTime = 4;
    float createCharacterTimer = 0;

    float offsetHeightSpawner = 0.1f;
    float doActionTime = 2;
    float doActionTimer = 0;

    const float restartTime = 2;
    float restartTimer = 0;

    //float charactersInDestiny = 0;
    //float charactersEliminated = 0;
    bool isGameOver = false;


    // podemos hacer una matriz ya que en ningun momento va a haber 2 characters en una misma casilla


    void Start()
    {
        hudmanager = HUDManagerGameObject.GetComponent<HUDManager>();
        soundManager = soundManagerGameObject.GetComponent<SoundManager>();
        //soundManager.playAudioSourceGameOver();
        hudmanager.setHP(initialHP);
        hudmanager.setArrived(initialDisabledArrived);
        hudmanager.setPenalization(initialPenalization);
        characterInstantiationParent = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);

        characterInstantiationParent.name = "Characters";
        characters = new List<GameObject>();
        //createMap();
        //spawnerGameObject = Instantiate(cellPrefab,
        //new Vector3(2, 0, 0), Quaternion.identity);
        // createCharacterTimer = createCharacterTime; // para que no tarde el tiempo maximo en instanciarlo
        // gameOver();
        createCharacter();//initial character
    }

    void createCharacter()
    {
        //characterInstantiationParent = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
        characterInstantiationParent.name = "Characters";
        Vector3 positionSpawner = spawnerGameObject.transform.position;
        GameObject createdCharacter = Instantiate(characterPrefab,
            new Vector3(positionSpawner.x, positionSpawner.y + offsetHeightSpawner, positionSpawner.z), Quaternion.identity);
        createdCharacter.transform.rotation = spawnerGameObject.transform.rotation;
        Character characterScript = createdCharacter.GetComponent<Character>();

        GameObject created3dModel = instantiateRandom3DModel(createdCharacter);
        //created3dModel.transform.rotation = spawnerGameObject.transform.rotation;
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
        Character characterScript = characterGameObject.GetComponent<Character>();
        //characterScript.myDisability = (Character.disabilites) rand;
        //characterScript.myDisability = Character.disabilites.alzheimer; 
        created3dModel.transform.SetParent(characterGameObject.transform, false);
        //created3dModel.transform.Rotate(Vector3.up * -90, Space.World);
        characterGameObject.GetComponent<Character>().myDisability = (Character.disabilites)rand;
        //Debug.Log("-> " + (Character.disabilites) rand + " - " +characterGameObject.GetComponent<Character>().myDisability);
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
    /*public void characterSaved()
    {
        numCharactersSaved++;
    }
    public void increaseScore()
    {
        characters++;
    }*/

    public void addPenalty()
    {
        penalization++;
        hudmanager.setPenalization(penalization);
    }

    public void addArrivedDisabled()
    {
        disabledArrived++;
        hudmanager.setArrived(disabledArrived);
    }

    public void decreaseScoreCharacterEliminated()
    {
        //charactersEliminated++; //no need? hp lo sustituye 
        HP--;
        hudmanager.setHP(HP);
        if (HP == 0)
        {
            gameOver();
        }

    }
    void calculateEndScore()
    {
        endScore = disabledArrived - penalization;
    }
    void gameOver()
    {
        isGameOver = true;
        //soundManager.playAudioSourceGameOver();
        //call game over in hud manager 
        // Debug.Log("GameOver");
        calculateEndScore();
        //print("GameOver");
        hudmanager.gameOver();
        hudmanager.setPenalizationScoreText(penalization);
        hudmanager.setDisabledArrivedScoreText(disabledArrived);
        hudmanager.setEndScoreText(endScore);
    }
    public void restartLevel()
    {
        hudmanager.disableScorePanel();
        // when we will build the project will not be dark after restarting level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void removeCharacterFromList(GameObject characterGameObject)
    {
        //print(characters.Count);
        characters.Remove(characterGameObject);
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
            if (!isGameOver) // paramos los movimientos de los jugadores
            {
                callToAction();
            }
        }
        doActionTimer += Time.deltaTime;
        if (restartTimer > restartTime)
        {
            restartLevel();
        }
        if (isGameOver)
        {
            restartTimer += Time.deltaTime;
        }
    }
}

