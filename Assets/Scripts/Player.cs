using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 10;
    Vector3 moveInput;

    Rigidbody rb;
    Camera cam;
    Motor motor;

    public Gun currentGun;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        motor = GetComponent<Motor>();
        UpdateMoveSpeed();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.instance.isPaused)
            return;

        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        motor.MoveTowards(moveInput);

        Ray CameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane eyePlane = new Plane(Vector3.up, Vector3.zero);

        if (eyePlane.Raycast(CameraRay, out float cameraDist))
        {
            Vector3 lookPoint = CameraRay.GetPoint(cameraDist);
            Vector3 eyeLookPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);


            transform.LookAt(eyeLookPoint);
            
        }

        if(Input.GetButton("Fire1"))
        {
            currentGun.Fire();
        }
    }

    void UpdateMoveSpeed()
    {
        motor.ChangeMoveSpeed(moveSpeed);
    }
}
