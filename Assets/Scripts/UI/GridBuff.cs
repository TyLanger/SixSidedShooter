using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuff : DieSlot
{
    public DieSlot helper;
    public FloorGrid floorGrid;

    protected override void Evaluate()
    {
        base.Evaluate();
        int helperValue = helper.GetValue();
        if(isFull)
        {
            if(helperValue > 0)
            {
                floorGrid.BuffSquare(GetValue(), helperValue);
            }
        }
    }
}
