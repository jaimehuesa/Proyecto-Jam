using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public Text m_MyText;
    // Use this for initialization
    float generalTimerSeconds = 0;
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        generalTimerSeconds += Time.deltaTime;
        string minutes = Mathf.Floor(generalTimerSeconds / 60).ToString("00");
        string seconds = (generalTimerSeconds % 60).ToString("00");
        m_MyText.text = minutes+" : "+ generalTimerSeconds;
        print(generalTimerSeconds);
    }
   
}
