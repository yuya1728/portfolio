using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBoxManager : MonoBehaviour
{
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        if(gameManager.GetComponent<GameManager>().isBallMoving == false)
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;
            float z = 100.0f;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, z));
        }
    }
}
