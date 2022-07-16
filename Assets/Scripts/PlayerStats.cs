using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    Player player;

    // all types of buffs here
    int currentGun = 6;
    int damageBoost = 0;
    int moveSpeedBoost = 0;
    int healAmount = 0;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void Reset()
    {
        // reset each stat
        currentGun = 6;
        damageBoost = 0;
        moveSpeedBoost = 0;
        healAmount = 0;
    }

    public void PushChanges()
    {
        // order of operations happens here

        player.ChangeGuns(currentGun);
        player.BuffDamage(damageBoost);
        player.BuffMoveSpeed(moveSpeedBoost);
        player.GetComponent<Health>().Heal(healAmount);
    }


    // Add new methods here
    public void SelectGun(int value)
    {
        currentGun = value;
    }

    public void BuffDamage(int value)
    {
        damageBoost = value;
    }

    public void BuffMoveSpeed(int value)
    {
        moveSpeedBoost = value;
    }

    public void Heal(int value)
    {
        healAmount = value;
    }
}
