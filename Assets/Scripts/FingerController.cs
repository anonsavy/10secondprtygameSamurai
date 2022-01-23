using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FingerController : MonoBehaviour
{
    public float speed = 2.0f;

    public static bool gameLose = false;

    public static bool gameTimeLose = false;

    public static bool gameWin = false;

    

    float currentTime = 0f; 

    float startingTime = 10f; 

    public Text countdownText; 

    public GameObject victoryBox;

    public GameObject loseBox; 

    public GameObject introBox; 

    public GameObject standardBG; 

    public GameObject waveBG; 

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    AudioSource audioSource;

    public AudioClip musicBG;
    public AudioClip yoEffect; 
    public AudioClip fartEffect;
    public AudioClip timeRunout; 
    

    void Start()
    {
        //FingerController.victoryBox<SpriteRenderer>().enabled = false;
        //loseBox<SpriteRenderer>().enabled = false;
        //introBox<SpriteRenderer>().enabled = false;

        victoryBox.GetComponent<SpriteRenderer>().enabled = false; 
        loseBox.GetComponent<SpriteRenderer>().enabled = false; 
       // introBox.GetComponent<SpriteRenderer>().enabled = true; 
        waveBG.GetComponent<SpriteRenderer>().enabled = false;
        standardBG.GetComponent<SpriteRenderer>().enabled = true;

        Destroy(introBox, 3);

        rigidbody2d = GetComponent<Rigidbody2D>();

        audioSource= GetComponent<AudioSource>();

        audioSource.clip = musicBG; 
        audioSource.loop = true; 
        audioSource.Play(); 

        currentTime = startingTime; 
        
        

    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Ear"))
        {
            
            audioSource.Stop(); 
            audioSource.clip = yoEffect;
            audioSource.loop = false; 
            audioSource.Play();
            GetComponent<Collider2D>().enabled = false; 
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezePosition;
            speed = 0.0f; 
            currentTime = 10; 
            //introBox.GetComponent<SpriteRenderer>().enabled = false; 
            standardBG.GetComponent<SpriteRenderer>().enabled = false;
            waveBG.GetComponent<SpriteRenderer>().enabled = true;
            victoryBox.GetComponent<SpriteRenderer>().enabled = true;
            gameWin = true; 
    
        }

        if (other.CompareTag("Head"))
        {
            
            audioSource.Stop(); 
            audioSource.clip = fartEffect;
            audioSource.loop = false; 
            audioSource.Play();
            GetComponent<Collider2D>().enabled = false; 
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezePosition;
            speed = 0.0f; 
            currentTime = 10; 
            //introBox.GetComponent<SpriteRenderer>().enabled = false; 
            loseBox.GetComponent<SpriteRenderer>().enabled = true; 
            gameLose = true; 
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");

        rigidbody2d.AddForce(new Vector2(horizontal * speed, vertical * speed));

        currentTime -= 1 * Time.deltaTime; 
        countdownText.text = currentTime.ToString ("0"); 

        if (gameWin == true)
        {
            currentTime += Time.deltaTime; 
            Destroy(countdownText); 
            
        }

        if (gameLose == true)
        {
            currentTime += Time.deltaTime; 
            Destroy(countdownText); 
            
        }

        if(currentTime <= 0)
        {
            gameTimeLose = true;
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezePosition;
            speed = 0.0f;
            loseBox.GetComponent<SpriteRenderer>().enabled = true; 
            currentTime += Time.deltaTime; 
            Destroy(countdownText); 
        }

        

        if (gameTimeLose == true)
        {
            audioSource.Stop(); 
            audioSource.clip = timeRunout;
            audioSource.loop = false; 
            audioSource.Play();
        }

        if (currentTime <= 3.5)
        {
            countdownText.color = Color.red;
        }

        if (Input.GetKey("escape"))
        {
          Application.Quit();
        }

         if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameWin == true)
            {       
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (gameLose == true)
            {       
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (gameTimeLose == true)
            {       
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

    }
}
