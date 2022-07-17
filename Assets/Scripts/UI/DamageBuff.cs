using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuff : DieSlot
{

    //string tooltip = "Boosts damage by die.";

    protected override void Evaluate()
    {
        base.Evaluate();
        if(isFull)
        {
            diceMenu.playerStats.BuffDamage(GetValue());
        }
        
    }
}
