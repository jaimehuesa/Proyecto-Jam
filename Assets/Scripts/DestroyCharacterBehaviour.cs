using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCharacterBehaviour : MonoBehaviour {
    public GameObject smokePrefab;
	// Use this for initialization
    void instantiateSmoke()
    {
        GameObject smokeObj = Instantiate(smokePrefab, transform.position, Quaternion.identity);
        ParticleSystem parts = smokeObj.GetComponent<ParticleSystem>();
        var main = parts.main;
        float totalDuration = main.duration + main.startLifetime.constant;
       //float totalDuration = 4;
        Destroy(smokeObj, totalDuration);
    }
	void Start () {
        instantiateSmoke();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
