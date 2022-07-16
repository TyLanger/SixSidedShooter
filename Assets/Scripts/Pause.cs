using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool isPaused = false;
    public static Pause instance;

    public event System.Action<bool> OnPauseToggle;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        OnPauseToggle?.Invoke(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }
}
