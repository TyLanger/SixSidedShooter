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

    void UnHook()
    {
        diceMenu.OnRoll -= Roll;

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

    public void DestroyTempDie()
    {
        //Debug.Log($"Destroy temp die {name}");
        UnHook();
        diceMenu.OnTempDieUsed -= DestroyTempDie;
        // this method might be being called before stats.evaluate
        // so the die and its value are gone before being recorded
        //StartCoroutine(LateDestroy());
        diceMenu.OnRoll += LateDestroy;
    }

    void LateDestroy()
    {
        //Debug.Log($"Late destroy temp die {name}");

        //yield return new WaitForSeconds(2);
        diceMenu.OnRoll -= LateDestroy;

        Destroy(this.gameObject);

    }
}
