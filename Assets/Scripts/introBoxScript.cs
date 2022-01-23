using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introBoxScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip introMusic;

    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        audioSource.clip = introMusic; 
        audioSource.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
