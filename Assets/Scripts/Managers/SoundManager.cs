using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


    public GameObject soundGameObjectPrefab;
    public GameObject listenerGameObject;


    /*GameObject audioSourceEliminatedGameObject;
    GameObject audioSourcePenalizationGameObject;
    GameObject audioSourceArrivedGameObject;
    GameObject audioSourceLevelMusicGameObject;
    GameObject audioSourceGameOverGameObject;*/

    public AudioClip audioClipEliminated, audioClipPenalization
        , audioClipArrived, audioClipLevelMusic, audioClipGameOver;

    public AudioSource audioSourceEliminated, audioSourcePenalization
     , audioSourceArrived, audioSourceLevelMusic, audioSourceGameOver;


    // Use this for initialization
    void Start() {
        //AudioSource audioSource = GetComponent<AudioSource>();

        /*AudioSource audioSourceEliminated = audioSourceEliminatedGameObject.GetComponent<AudioSource>();
        AudioSource audioSourcePenalization = audioSourcePenalizationGameObject.GetComponent<AudioSource>();
        AudioSource audioSourceArrived = audioSourceArrivedGameObject.GetComponent<AudioSource>();
        AudioSource audioSourceLevelMusic = audioSourceLevelMusicGameObject.GetComponent<AudioSource>();
        AudioSource audioSourceGameOver = audioSourceGameOverGameObject.GetComponent<AudioSource>();*/
    }
    public void playAudioSourcePenalization() { audioSourceEliminated.Play(); }
    public void playAudioSourceArrived() { audioSourcePenalization.Play(); }
    public void playAudioSourceEliminated() { audioSourceArrived.Play(); }
    public void playAudioSourceLevelMusic() { audioSourceLevelMusic.Play(); }
    public void playAudioSourceGameOver() { audioSourceGameOver.Play(); }
    // Update is called once per frame
    void Update() {

    }

    void playSound(AudioClip a_audioClip) {

    }

   /* AudioSource createPrefabSound(){
        GameObject goAudioSource Instantiate(soundGameObjectPrefab, listenerGameObject.transform.position());
        Instantiate(soundGameObjectPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        createdCharacter.transform.SetParent(characterInstantiationParent.transform, false);
        return goAudioSource.GetComponent<AudioSource>();
    }*/

    /*
     Instancias prefabs con audioSource
     la nueva 
      audioSourceEliminatedGameObject=Insta

     */
}
