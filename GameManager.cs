using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public int StageNo;
    public string yes;
    public bool isBallMoving;
  
    public int destroyCount;

    public GameObject ballPrefab;
    public GameObject ball;

    public GameObject goButton;
    public GameObject retryButton;
    public GameObject backButton;
    public GameObject clearText;
    public Text ballIcon_text;
    public Text StageNametext;
    public GameObject ballIcon;

    public AudioClip clearSE, goSE, retrySE, backSE;
    private AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive(false);
        isBallMoving = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("HARD") == 2)
        {
            backButton.SetActive(false);
            if (StageNo > 1)
            {
                destroyCount = PlayerPrefs.GetInt("D");
                ballIcon_text.text = "×" + destroyCount;
            }
        }
        else if (PlayerPrefs.GetInt("HARD") == 1)
        {
            destroyCount = PlayerPrefs.GetInt("DH"+StageNo,destroyCount);
            ballIcon_text.text = "×" + destroyCount;
        }
            if (PlayerPrefs.GetInt("HARD") == 1 || PlayerPrefs.GetInt("HARD") == 2)
        {
           ballIcon.SetActive(true);
           
        }
        else
        {
            ballIcon.SetActive(false);
        }            
        StageNametext.text = "Stage" + StageNo;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void PushGoButton()
    {
        Rigidbody2D rd = ball.GetComponent<Rigidbody2D>();
        rd.isKinematic = false;

        retryButton.SetActive(true);
        goButton.SetActive(false);
        isBallMoving = true;
        audioSource.PlayOneShot(goSE);
    }

    public void PushRetryButton()
    {
        Destroy(ball);

        ball = (GameObject)Instantiate(ballPrefab);
        retryButton.SetActive(false);
        goButton.SetActive(true);
        isBallMoving = (false);
        audioSource.PlayOneShot(retrySE);
        if(PlayerPrefs.GetInt("HARD") == 1 || PlayerPrefs.GetInt("HARD") == 2)
            {
                UpdatePlayerIcons();
            }
    }

    public void PushBackButton()
    {
        audioSource.PlayOneShot(backSE);
        Invoke("GobackStageSelect", 0.3f);
    }

    public void StageClear()
    {
        audioSource.PlayOneShot(clearSE);
       
        if (PlayerPrefs.GetInt("CLEAR"+PlayerPrefs.GetInt("HARD"), 0) < StageNo)
        {
            PlayerPrefs.SetInt("CLEAR"+PlayerPrefs.GetInt("HARD"), StageNo);

        }
        clearText.SetActive(true);
        retryButton.SetActive(false);
        PlayerPrefs.SetInt("D", destroyCount);
        PlayerPrefs.DeleteKey("DH" + StageNo);

        if (GameObject.FindGameObjectWithTag("Finish") == true)
        {
            if (PlayerPrefs.GetString("FIRST") == "yes")
            {
                Invoke("FinalStageClearScene", 2.0f);
            }
            else
            {
                PlayerPrefs.SetString("FIRST", "yes");

                PlayerPrefs.SetFloat("TIME2", Time.time);
                Invoke("AllClearScene", 2.0f);
            }
        }
        if(PlayerPrefs.GetInt("HARD") == 2)
        {
            Invoke("VeryHard", 3.0f);
        }else
        {
            Invoke("GobackStageSelect", 3.0f);
        }
    }

    void AllClearScene()
    {
        if (PlayerPrefs.GetInt("HARD") == 0)
        {
            PlayerPrefs.SetString("STAGE", "hard");
        }
        else if(PlayerPrefs.GetInt("HARD")==1)
        {
            PlayerPrefs.SetString("STAGE", "very hard");
        }
        SceneManager.LoadScene("AllClearScene");
    }

    void FinalStageClearScene()
    {
        SceneManager.LoadScene("FinalStageClearScene");
    }

    private void VeryHard()
    {
        StageNo++;
        SceneManager.LoadScene("PuzzleScene" + StageNo);
    }
    void GobackStageSelect()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    public void UpdatePlayerIcons()
    {
        destroyCount--;
          
        ballIcon_text.text = "×" + destroyCount;
        PlayerPrefs.SetInt("DH"+StageNo,destroyCount);
        if (destroyCount == 0)
        {
            PlayerPrefs.DeleteKey("CLEAR" + PlayerPrefs.GetInt("HARD"));
            PlayerPrefs.DeleteKey("TIME1");
            PlayerPrefs.DeleteKey("TIME2");         
            for (int i = 1; i <=StageNo; i++)
            {
                PlayerPrefs.DeleteKey("DH" + i);
            }
            SceneManager.LoadScene("GameOverScene");
        }

    }

   
}
    
