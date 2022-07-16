using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedBoost : DieSlot
{
    string tooltip = "Boosts move speed by die.";

    protected override void Evaluate()
    {
        base.Evaluate();
        if(isFull)
        {
            diceMenu.playerStats.BuffMoveSpeed(GetValue());
        }
    }
}
