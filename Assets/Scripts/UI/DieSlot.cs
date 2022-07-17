using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DieSlot : ItemSlot
{

    protected DiceMenuController diceMenu;
    public int[] blockedNumbers;

    private void Awake()
    {
        diceMenu = FindObjectOfType<DiceMenuController>();
        SetHooks();
    }

    public override void OnDrop(PointerEventData eventData)
    {
        // override features:
        // blocked numbers
        // if it fails, it resets its position
        // maybe it can't see another die when its full because it doesn't raycast?


        if(eventData.pointerDrag != null)
        {
            UIDie newDie = eventData.pointerDrag.GetComponent<UIDie>();
            int newNum = newDie.GetValue();
            bool rightNumber = true;
            foreach (int num in blockedNumbers)
            {
                if (newNum == num)
                {
                    rightNumber = false;
                    break;
                }
            }
            if (!isFull && rightNumber)
            {
                newDie.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                isFull = true;
                item = newDie;
                item.OnDieLifted += Release;
                currentName = item.name + ": " + newNum;
            }
            else
            {
                newDie.ResetPos();
            }
        }
    }

    void SetHooks()
    {
        diceMenu.OnDieEvaluation += Evaluate;
        // clear old dice
        diceMenu.OnRoll += Release;
    }

    protected virtual void Evaluate()
    {
        if(!isFull)
        {
            return;
        }
    }

    public int GetValue()
    {
        if(isFull)
            return item.GetValue();
        return 0;
    }

}
