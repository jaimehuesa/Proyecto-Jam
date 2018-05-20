using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource audioSourceEliminated;
    public AudioSource audioSourcePenalization;
    public AudioSource audioSourceArrived;
    public AudioSource audioSourceLevelMusic;
    public AudioSource audioSourceGameOver;
    // Use this for initialization
    void Start () {
		//AudioSource audioSource = GetComponent<AudioSource>();
        
	}
    public void playAudioSourcePenalization() { audioSourceEliminated.Play(); }
    public void playAudioSourceArrived() { audioSourcePenalization.Play();}
    public void playAudioSourceEliminated() { audioSourceArrived.Play(); }
    public void playAudioSourceLevelMusic() { audioSourceLevelMusic.Play(); }
    public void playAudioSourceGameOver() { audioSourceGameOver.Play(); }
    // Update is called once per frame
    void Update () {
		
	}
}
