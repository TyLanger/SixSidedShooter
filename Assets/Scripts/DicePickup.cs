using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePickup : MonoBehaviour
{
    public float rotationSpeed = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            FindObjectOfType<DiceMenuController>().DicePickedUp();
            Destroy(gameObject);
        }
    }

}
