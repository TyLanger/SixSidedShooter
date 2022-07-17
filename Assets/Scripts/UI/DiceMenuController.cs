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
    public event Action OnTempDieUsed;

    //public Player player;
    public PlayerStats playerStats;

    public UIDie die;
    public Transform dieHolder;

    // Start is called before the first frame update
    void Awake()
    {
        pause.OnPauseToggle += OnPauseToggle;
        diceMenuHolder.gameObject.SetActive(false);

    }


    void OnPauseToggle(bool isPaused)
    {

        if(isPaused)
        {
            // need to activate them first
            diceMenuHolder.gameObject.SetActive(isPaused);

            RollDice();
            playerStats.Reset();
        }
        else
        {
            // this will send any relevent info to the stats
            EvaluateDiceSelection();
            // need to disable after they do stuff
            diceMenuHolder.gameObject.SetActive(isPaused);
            // tell the stats manager to update the player
            playerStats.PushChanges();
            OnTempDieUsed?.Invoke();
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

    public void DicePickedUp()
    {
        //Debug.Log("Picked up");
        var copy = Instantiate(die, dieHolder);
        OnTempDieUsed += copy.DestroyTempDie;
    }
}
