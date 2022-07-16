using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourEnemy : Enemy
{
    bool wallMode = true;
    Vector3 wallDir;
    public float wallDuration = 10;

    protected override void Update()
    {
       

        if (wallMode)
        {
            wallDuration -= Time.deltaTime;
            if (wallDuration < 0)
                wallMode = false;
            motor.MoveTowards(wallDir);
        }
        else
        {
            base.Update();
        }
    }

    public void WallMode(Vector3 direction, float duration)
    {
        wallMode = true;
        wallDir = direction;
        wallDuration = duration;
    }

}
