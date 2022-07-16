using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{

    public Transform target;

    public float rotationSpeed = 10;

    public Projectile[] orbiters;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = target.position;
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DamageBoostOrbiters(int boost)
    {
        if(orbiters != null)
        {
            if(orbiters.Length > 0)
            {
                for (int i = 0; i < orbiters.Length; i++)
                {
                    orbiters[i].Setup(0, boost);
                }
            }
        }
    }
}
