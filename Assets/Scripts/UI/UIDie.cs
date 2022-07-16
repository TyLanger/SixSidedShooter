using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDie : DragDrop
{


    [SerializeField] int value = 1;

    DiceMenuController diceMenu;

    Vector2 spawnPos;

    public Sprite[] diceFaces;
    Image image;

    protected override void Awake()
    {
        base.Awake();
        spawnPos = rectTransform.anchoredPosition;

        diceMenu = FindObjectOfType<DiceMenuController>();
        image = GetComponent<Image>();
        SetHooks();
    }

    void SetHooks()
    {
        diceMenu.OnRoll += Roll;
    }

    public void Roll()
    {
        ResetPos();
        value = Random.Range(1, 7);
        image.sprite = diceFaces[value - 1];
    }

    public void ResetPos()
    {
        rectTransform.anchoredPosition = spawnPos;
    }

    public int GetValue()
    {
        return value;
    }
}
