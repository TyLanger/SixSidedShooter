using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayDamage : DieSlot
{
    public DieSlot helper;

    protected override void Evaluate()
    {
        base.Evaluate();
        int helperValue = helper.GetValue();
        if(isFull)
        {
            diceMenu.playerStats.BuffDamageDecay(GetValue(), helperValue);
        }
    }
}
