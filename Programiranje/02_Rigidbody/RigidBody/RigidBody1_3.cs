using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBody1_3 : MonoBehaviour
{
    //Napravite skriptu koja ima javnu varijablu health i javnu
    //varijablu healthRegeneration.
    //Kada kocka  udje u sferu neka primi damage 10.
    //Dok je u sferu gubi 10 health-a po sekundi
    //a kada izadje iz sfere krene sa regeneracijom i
    //regenerira se po sekundi za 5.

    public float health;
    public float healthRegeneration;
    public bool isRegenerate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sfera"))
        {
            isRegenerate = false;
            health -= 10;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Sfera"))
        {
            health -= 10 * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Sfera"))
        {
            isRegenerate = true;
        }
    }

    private void Update()
    {
        if (isRegenerate)
        {
            health += healthRegeneration * Time.deltaTime;
            if(health > 100)
            {
                health = 100;
                isRegenerate = false;
            }
        }
    }

}
