using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDie : DragDrop
{


    [SerializeField] int value = 1;

    DiceMenuController diceMenu;

    Vector2 spawnPos;

    protected override void Awake()
    {
        base.Awake();
        spawnPos = rectTransform.anchoredPosition;

        diceMenu = FindObjectOfType<DiceMenuController>();
        SetHooks();
    }

    void SetHooks()
    {
        diceMenu.OnRoll += Roll;
    }

    public void Roll()
    {
        rectTransform.anchoredPosition = spawnPos;
        value = Random.Range(1, 7);
    }

    public int GetValue()
    {
        return value;
    }
}
