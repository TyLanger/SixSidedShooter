using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSlot : DieSlot
{
    string tooltip = "Heal for die amount";

    protected override void Evaluate()
    {
        base.Evaluate();
        if(isFull)
        {
            diceMenu.playerStats.Heal(GetValue());
        }
    }
}
