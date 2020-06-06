using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StageSelectManager : MonoBehaviour
{

    public GameObject[] stageButtons;
    private AudioSource audioSource4;
    public AudioClip SelectSE,backSE, DeleteSE;
    public GameObject timeatackButton;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("SCENE", 1);
        audioSource4 = gameObject.GetComponent<AudioSource>();
        int clearStageNo = PlayerPrefs.GetInt("CLEAR"+PlayerPrefs.GetInt("HARD"), 0);
        for(int i=0; i<=stageButtons.GetUpperBound(0); i++)
        {
            bool b;
            if (clearStageNo < i)
            {
                b = false;
            }
            else
            {
                b = true;
            }

            stageButtons[i].GetComponent<Button>().interactable = b;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(int stageNo)
    {
        audioSource4.PlayOneShot(SelectSE);
        if (stageNo == 1)
        {
            PlayerPrefs.SetFloat("TIME1", Time.time);
        }
        SceneManager.LoadScene("PuzzleScene" + stageNo);
       
    }

    public void PushBackButton()
    {
       
        audioSource4.PlayOneShot(backSE);
        Invoke("GobackTitle", 0.5f);
    }

    public void OnClick3()
    {

        audioSource4.PlayOneShot(SelectSE);
        Invoke("PushHelpButton", 0.5f);
    }

    public void PushHelpButton()
    {
        SceneManager.LoadScene("HelpScene");
    }
    void GobackTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void OnClick4()
    {

        audioSource4.PlayOneShot(DeleteSE);
        Invoke("PushTimeAtackButton", 0.5f);
    }
    public void PushTimeAtackButton()
    {
        PlayerPrefs.DeleteKey("CLEAR" + PlayerPrefs.GetInt("HARD"));
        PlayerPrefs.DeleteKey("TIME1");
        PlayerPrefs.DeleteKey("TIME2");
        PlayerPrefs.DeleteKey("FIRST");
        for (int i = 1; i <= stageButtons.Length; i++)
        {
            PlayerPrefs.DeleteKey("DH" + i);
        }
        Invoke("GobackTitle", 0.5f);
    }
}
