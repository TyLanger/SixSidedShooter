using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedMags : DieSlot
{
    protected override void Evaluate()
    {
        base.Evaluate();
        if(isFull)
        {
            diceMenu.playerStats.ExtendMags(GetValue());
        }
    }
}
