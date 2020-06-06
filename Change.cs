using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Change : MonoBehaviour
{
    public string NextScene;
    // Start is called before the first frame update
    void Start()
    {
        

    }
    void ChangeNext()
    {
        if (Time.timeSinceLevelLoad > 10.0f)
        {
            SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
        }
    }
    // Update is called once per frame
    void Update()
    {
        ChangeNext();
    }
}
