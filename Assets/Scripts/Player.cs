using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 10;
    Vector3 moveInput;
    int moveSpeedBoost = 0;

    Camera cam;
    Motor motor;
    Health health;


    public Gun currentGun;

    public Gun[] allGuns;

    // Start is called before the first frame update
    void Awake()
    {
        health = GetComponent<Health>();
        health.OnDeath += Death;
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
        motor.ChangeMoveSpeed(moveSpeed + moveSpeedBoost);
    }

    void Death()
    {
        Debug.Log("You've died");
    }

    public void ChangeGuns(int value)
    {
        currentGun = allGuns[value - 1];
    }

    public void ClipExtend(int value)
    {
        currentGun.ClipExtend(value);
    }

    public void BuffDamage(int damageBoost)
    {
        currentGun.BuffDamage(damageBoost);
    }

    public void BuffMoveSpeed(int value)
    {
        moveSpeedBoost = value;
        UpdateMoveSpeed();
    }
}
