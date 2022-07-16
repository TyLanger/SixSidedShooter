using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool isPaused = false;
    public static Pause instance;

    public event System.Action<bool> OnPauseToggle;

    public float timeBank = 0;
    public float timeNeededToPause = 60;
    public float maxTimeBetweenPauses = 30;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timeBank += Time.deltaTime;

        if (Input.GetButtonDown("Jump") || timeBank > maxTimeBetweenPauses)
        {
            TogglePause();
        }

    }

    void TogglePause()
    {
        if(!isPaused)
        {
            if(timeBank < timeNeededToPause)
            {
                return;
            }
            timeBank = 0;
        }
        isPaused = !isPaused;
        OnPauseToggle?.Invoke(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }
}
