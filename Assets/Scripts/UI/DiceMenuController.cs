using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMenuController : MonoBehaviour
{

    public Transform diceMenuHolder;
    public Pause pause;

    public event Action OnRoll;
    public event Action OnDieEvaluation;

    // Start is called before the first frame update
    void Awake()
    {
        pause.OnPauseToggle += OnPauseToggle;
    }


    void OnPauseToggle(bool isPaused)
    {

        if(isPaused)
        {
            // need to activate them first
            diceMenuHolder.gameObject.SetActive(isPaused);

            RollDice();
        }
        else
        {
            EvaluateDiceSelection();
            // need to disable after they do stuff
            diceMenuHolder.gameObject.SetActive(isPaused);
        }
    }

    void RollDice()
    {
        OnRoll?.Invoke();
    }

    void EvaluateDiceSelection()
    {
        OnDieEvaluation?.Invoke();
    }
}
