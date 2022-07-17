using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    Player player;
    public EnemySpawnDirector enemySpawner;

    // all types of buffs here
    int currentGun = 6;
    int damageBoost = 0;
    int moveSpeedBoost = 0;
    int healAmount = 0;
    int clipAmount = 0;

    // decays
    int damageBoostDecay = 0;
    int boostDecayIn = 1;

    int killsSincePause = 0;

    private void Awake()
    {
        player = GetComponent<Player>();
        enemySpawner.OnEnemyDeath += Decay;
    }

    public void Reset()
    {
        // reset each stat
        currentGun = 6;
        damageBoost = 0;
        moveSpeedBoost = 0;
        healAmount = 0;
        clipAmount = 0;

        // decay
        damageBoostDecay = 0;
        boostDecayIn = 1;

        killsSincePause = 0;
    }

    public void PushChanges()
    {
        // order of operations happens here

        player.ChangeGuns(currentGun);
        player.BuffDamage(damageBoost);
        player.BuffDamage(damageBoostDecay);
        player.BuffMoveSpeed(moveSpeedBoost);
        player.GetComponent<Health>().Heal(healAmount);
        healAmount = 0;
        player.ClipExtend(clipAmount);
        

    }

    void Decay()
    {
        killsSincePause++;
        bool anyChanges = false;

        if (damageBoostDecay > 0 && killsSincePause % boostDecayIn == 0)
        {
            damageBoostDecay--;
            //Debug.Log($"Lost damage: {damageBoostDecay + 1} -> {damageBoostDecay}");
            anyChanges = true;
        }

        if(anyChanges)
        {
            //Debug.Log($"Changes on kill {killsSincePause}");
        }
        PushChanges();
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

    public void BuffDamageDecay(int damage, int decay)
    {
        damageBoostDecay = damage;
        boostDecayIn = decay + 1;
    }

    public void ExtendMags(int value)
    {
        clipAmount = value;
    }
}
