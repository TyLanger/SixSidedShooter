using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    Player player;

    // all types of buffs here
    int damageBoost = 0;


    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void Reset()
    {
        // reset each stat
        damageBoost = 0;
    }

    public void PushChanges()
    {
        // order of operations happens here

        // player.ChangeGuns(gunIndex)
        player.BuffDamage(damageBoost);
    }


    // Add new methods here
    public void BuffDamage(int value)
    {
        damageBoost = value;
    }
}
