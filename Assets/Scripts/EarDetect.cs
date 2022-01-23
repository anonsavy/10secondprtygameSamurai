using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarDetect : MonoBehaviour
{

    Animator SamuraiNorm;
    AudioSource audioSource;
    public AudioClip introMusic;

    void Start()
    {
        SamuraiNorm = GetComponent<Animator>();
        audioSource= GetComponent<AudioSource>();
        audioSource.clip = introMusic; 
        audioSource.Play(); 
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Finger"))
        {
           SamuraiNorm.SetInteger("Touch", 2);
           Debug.Log("TOUCHED"); 
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
