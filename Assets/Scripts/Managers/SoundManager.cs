using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{


    public GameObject soundGameObjectPrefab;
    public GameObject listenerGameObject;

    public AudioClip audioClipEliminated, audioClipPenalization
        , audioClipArrived, audioClipLevelMusic, audioClipGameOver;

    AudioSource audioSourceEliminated, audioSourcePenalization
     , audioSourceArrived, audioSourceLevelMusic, audioSourceGameOver;


    // Use this for initialization
    void Start()
    {
        audioSourceEliminated = createPrefabSound(audioClipEliminated);
        audioSourcePenalization = createPrefabSound(audioClipPenalization); 
        audioSourceArrived = createPrefabSound(audioClipArrived); 
        audioSourceLevelMusic = createPrefabSound(audioClipLevelMusic); 
        audioSourceGameOver = createPrefabSound(audioClipGameOver);
        audioSourceLevelMusic.loop = true;
    }
    public void playAudioSourceEliminated() { playSound(audioSourceEliminated); }
    public void playAudioSourcePenalization() { playSound(audioSourcePenalization); }
    public void playAudioSourceArrived() { playSound(audioSourceArrived); }
    public void playAudioSourceLevelMusic() { playSound(audioSourceLevelMusic); }
    public void playAudioSourceGameOver() { playSound(audioSourceGameOver); }
    // Update is called once per frame
    void Update()
    {

    }
    AudioSource createPrefabSound(AudioClip a_audioClip)
    {
        GameObject soundGameObject = Instantiate(soundGameObjectPrefab, listenerGameObject.transform.position, Quaternion.identity);
        soundGameObject.transform.SetParent(listenerGameObject.transform, false);
        AudioSource audioS=soundGameObject.GetComponent<AudioSource>();
        audioS.clip = a_audioClip;
        return audioS;
    }

    void playSound(AudioSource a_audioSource)
    {
        //instantiate
        if (!a_audioSource.isPlaying)
        {
            a_audioSource.Play();
        }
    }

    

}
