using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpScene : MonoBehaviour
{
    public GameObject CanvasHelp, CanvasHelp2;

    private AudioSource audioSource3;
    public AudioClip StartSE, backSE;
    // Start is called before the first frame update
    void Start()
    {
        audioSource3 = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick4()
    {
        audioSource3.PlayOneShot(StartSE);
        CanvasHelp.SetActive(false);
        CanvasHelp2.SetActive(true);
    }

    public void OnClick5()
    {
        audioSource3.PlayOneShot(backSE);
        CanvasHelp.SetActive(true);
        CanvasHelp2.SetActive(false);
    }

    public void PushBackButton()
    {
        audioSource3.PlayOneShot(backSE);
        Invoke("Goback", 0.5f);
    }

    void Goback()
    {
        if (PlayerPrefs.GetInt("SCENE") == 0)
        {
            SceneManager.LoadScene("TitleScene");
        }else if(PlayerPrefs.GetInt("SCENE") == 1)
        {
            SceneManager.LoadScene("StageSelectScene");
        }


    }
}
