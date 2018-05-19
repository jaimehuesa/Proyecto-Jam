using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public Text timerText, HPText,disabledArrivedText, penalizationText;
    
    

    // Use this for initialization
    float generalTimerSeconds = 0;
    void Start () {
        //setHP(initialHP);
    }
	
	// Update is called once per frame
	void Update () {
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
        HPText.text= a_HP.ToString();
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
        //instantiate canvas game over
    }


}
