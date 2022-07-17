using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCube : MonoBehaviour
{

    MeshRenderer mesh;
    BoxCollider box;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        box = GetComponent<BoxCollider>();
    }

    public void Activate()
    {
        mesh.enabled = true;
        box.enabled = true;
    }

    public void Deactivate()
    {
        mesh.enabled = false;
        box.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats p = other.GetComponent<PlayerStats>();
        if(p)
        {
            p.AreaBuff(2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerStats p = other.GetComponent<PlayerStats>();
        if (p)
        {
            p.AreaBuff(0);
        }
    }
}
