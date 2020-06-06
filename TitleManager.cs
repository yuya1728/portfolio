using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private AudioSource audioSource3;
    public AudioClip StartSE,DeleteSE,backSE;
    public int StageNo;
    public GameObject hardButton;
    public GameObject veryhardButton;
  
    // Start is called before the first frame update
    void Start()
    {
        audioSource3 = gameObject.GetComponent<AudioSource>();
        PlayerPrefs.SetInt("SCENE", 0);
        
       if( PlayerPrefs.GetString("STAGE")=="hard")
        {
            hardButton.SetActive(true);
        }
        if (PlayerPrefs.GetString("STAGE") == "very hard")
        {
            hardButton.SetActive(true);
            veryhardButton.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClick()
    {
        audioSource3.PlayOneShot(StartSE);
        PlayerPrefs.SetInt("HARD", 0);
        Invoke("PushStartButton", 0.5f);
    }
    public void PushStartButton()
    {
      
        SceneManager.LoadScene("StageSelectScene");
        
    }
    public void OnClickH()
    {
        audioSource3.PlayOneShot(StartSE);           
       
       
        PlayerPrefs.SetInt("HARD", 1);     
        Invoke("PushStartButton", 0.5f);
    }

    public void OnClickVH()
    {
        audioSource3.PlayOneShot(StartSE);            
        PlayerPrefs.DeleteKey("TIME1");
        PlayerPrefs.DeleteKey("TIME2");
        PlayerPrefs.DeleteKey("FIRST");
        PlayerPrefs.DeleteKey("D");
        PlayerPrefs.SetInt("HARD", 2);
        PlayerPrefs.DeleteKey("CLEAR" + PlayerPrefs.GetInt("HARD"));
        Invoke("PushStartButton", 0.5f);
    }

    public void OnClick2()
    {
        audioSource3.PlayOneShot(DeleteSE);
        Invoke("PushDeleteButton", 1.0f);
    }


    public void PushDeleteButton()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("TitleScene");
    }

    public void OnClick3()
    {

        audioSource3.PlayOneShot(StartSE);
        Invoke("PushHelpButton", 0.5f);
    }
   
    public void PushHelpButton()
    {      
        SceneManager.LoadScene("HelpScene");
    }

  
}
