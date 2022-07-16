using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool isPaused = false;
    public static Pause instance;


    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            isPaused = !isPaused;
            TogglePause();
        }
    }

    void TogglePause()
    {
        Time.timeScale = isPaused ? 0 : 1;
    }
}
