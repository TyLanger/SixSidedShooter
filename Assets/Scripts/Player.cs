using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 10;
    Vector3 moveInput;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + moveInput, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + (moveInput.normalized * moveSpeed * Time.fixedDeltaTime));
    }
}
