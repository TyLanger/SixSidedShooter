using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{

    public float lifetime = 3;


    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime < 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void SetText(int number)
    {
        GetComponent<TextMeshPro>().text = number.ToString();
    }
}
