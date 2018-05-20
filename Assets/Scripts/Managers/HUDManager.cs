using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public Text timerText, HPText, disabledArrivedText, penalizationText
        , disabledArrivedScoreText, penalizationScoreText, endScoreText;
    public GameObject scoreGameObject;

    // Use this for initialization
    float generalTimerSeconds = 0;
    void Start() {
        //setHP(initialHP);
    }

    // Update is called once per frame
    void Update() {
        generalTimerSeconds += Time.deltaTime;
        updateClockString();
        //print(generalTimerSeconds);
    }
    void updateClockString()
    {
        string minutes = Mathf.Floor(generalTimerSeconds / 60).ToString("00");
        string seconds = (generalTimerSeconds % 60).ToString("00");
        timerText.text = minutes + " : " + seconds;
    }
    public void setHP(int a_HP)
    {
        HPText.text = a_HP.ToString();
    }
    public void setArrived(int a_arrived)
    {
        disabledArrivedText.text = a_arrived.ToString();
    }
    public void setPenalization(float a_penalization)
    {
        //penalization = a_penalization;
        penalizationText.text = a_penalization.ToString();
    }

    public void gameOver()
    {
        enableScorePanel();
    }

    public void setDisabledArrivedScoreText(float a_disabledArrived)
    {
        disabledArrivedScoreText.text = a_disabledArrived.ToString();
    }
    public void setPenalizationScoreText(float a_penalization)
    {
        penalizationScoreText.text = a_penalization.ToString();

    }
    public void setEndScoreText(float a_endScore)
    {
        endScoreText.text = "Score: "+ a_endScore.ToString();
    }


    public void enableScorePanel()
    {
        EnableUIObject(scoreGameObject);
    }

    public void disableScorePanel()
    {
        DisableUIObject(scoreGameObject);
    }
    void EnableUIObject(GameObject go)
    {
        go.SetActive(true);
    }

    void DisableUIObject(GameObject go)
    {
        go.SetActive(false);
    }


}
