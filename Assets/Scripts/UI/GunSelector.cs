using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelector : DieSlot
{
    //string tooltip = "1: Rifle, 2: Shotgun, 3: Harpoon, 4: Wand, 5: ??, 6: Revolver.";

    protected override void Evaluate()
    {
        base.Evaluate();
        if(isFull)
        {
            diceMenu.playerStats.SelectGun(GetValue());
        }
    }
}
