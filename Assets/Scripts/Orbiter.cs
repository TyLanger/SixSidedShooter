using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{

    public Transform target;

    public float rotationSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
