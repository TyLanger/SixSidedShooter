using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSlot : ItemSlot
{

    protected DiceMenuController diceMenu;

    private void Awake()
    {
        diceMenu = FindObjectOfType<DiceMenuController>();
        SetHooks();
    }

    void SetHooks()
    {
        diceMenu.OnDieEvaluation += Evaluate;
        // clear old dice
        diceMenu.OnRoll += Release;
    }

    void Evaluate()
    {
        if (isFull)
        {
            Debug.Log($"Value: {item.GetValue()}");
        }
    }

}
