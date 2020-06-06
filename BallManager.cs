using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallManager : MonoBehaviour
{
    public AudioClip ballSE;
    private AudioSource audioSource2;


    // Start is called before the first frame update
    void Start()
    {
        audioSource2= gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "OutArea")
        {
            GameObject gameManager = GameObject.Find("GameManager");

            gameManager.GetComponent<GameManager>().PushRetryButton();
        }
        if (coll.gameObject.tag == "Box")
        {
            audioSource2.PlayOneShot(ballSE);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ClearArea")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().StageClear();

        }

       
    }

    
}
