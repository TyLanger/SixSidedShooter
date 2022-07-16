using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    int healthBarsLeft = 6;

    public Transform[] pivots;

    public int rotationSteps = 10;

    IEnumerator RotateSide(int pivotIndex)
    {
        motor.ChangeMoveSpeed(0);
        health.SetInvincible(true);
        
        float angle = 90 / rotationSteps;
        for (int i = 0; i < rotationSteps; i++)
        {
            transform.RotateAround(pivots[pivotIndex-1].position, pivots[pivotIndex-1].right, -angle);

            yield return new WaitForFixedUpdate();
        }

        motor.ChangeMoveSpeed(moveSpeed);
        health.SetInvincible(false);
    }


    protected void AdvanceToNextHealthBar()
    {
        DestroyFace();
        StartCoroutine(RotateSide(6 - healthBarsLeft));
        health.Heal(number);

    }

    void DestroyFace()
    {
        spriteRenderers[5-healthBarsLeft].enabled = false;
    }

    protected override void Death()
    {
        // ran out of health
        healthBarsLeft--;
        if(healthBarsLeft == 0)
        {
            base.Death();

        }
        else
        {
            AdvanceToNextHealthBar();
        }
    }
}
