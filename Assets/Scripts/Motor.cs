using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    Rigidbody rb;

    float moveSpeed = 0;
    Vector3 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveDirection = Vector3.zero;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (moveDirection * moveSpeed * Time.fixedDeltaTime));
        rb.velocity = Vector3.zero;
    }

    public void MoveTowards(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    public void ChangeMoveSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
}
