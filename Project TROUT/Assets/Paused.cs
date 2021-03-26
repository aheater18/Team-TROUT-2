using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] pausedObjects;

    void Start()
    {
        Time.timeScale = 1.0f;
        pausedObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0) {
                Time.timeScale = 1.0f;
                hidePaused();
            }
        }
    }

    public void hidePaused()
    {
        foreach (GameObject g in pausedObjects)
        {
            g.SetActive(false);
        }
    }

    public void showPaused()
    {
        foreach (GameObject g in pausedObjects)
        {
            g.SetActive(true);
        }
    }
}
