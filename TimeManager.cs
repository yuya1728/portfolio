using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    public Text time_text;
    public float timescore=0;

    // Start is called before the first frame update
    void Start()
    {

        timescore = PlayerPrefs.GetFloat("TIME2") - PlayerPrefs.GetFloat("TIME1");
        time_text.text = "time:"+timescore+ "秒";
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    


}
