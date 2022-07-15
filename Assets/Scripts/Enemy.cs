using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Health health;
    Motor motor;

    public Transform playerTrans;

    public int number = 1;
    public float moveSpeed = 6;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.maxHealth = number;

        motor = GetComponent<Motor>();
        motor.ChangeMoveSpeed(moveSpeed);
    }

    private void Update()
    {
        motor.MoveTowards(playerTrans.position - transform.position);
    }

}
