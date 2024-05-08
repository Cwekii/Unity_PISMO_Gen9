using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RigidBody1_2 : MonoBehaviour
{
    //napravite skriptu koja ima javnu varijablu health i javnu
    //varijablu healthRegeneration.
    //Kada kocka  dokatkne sferu neka primi damage 10.
    //Kada dira sferu gubi 10 health-a po sekundi
    //a kada prestane dirati sferu krene sa regeneracijom i
    //regenerira se po sekundi za 5.


    public float health;
    public float healthRegeneration;
    public bool isStopedTouch;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Sfera")
        {
            health -= 10f;
            isStopedTouch = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Sfera")
        {
            health -= 10f * Time.deltaTime;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Sfera")
        {
            isStopedTouch = true;
        }
    }

    private void Update()
    {
        if (isStopedTouch && health < 100)
        {
            health += 5f * Time.deltaTime;
            if(health > 100)
            {
                health = 100f;
            }
           

        }
    }
}
