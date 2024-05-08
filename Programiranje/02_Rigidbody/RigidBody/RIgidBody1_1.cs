using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIgidBody1_1 : MonoBehaviour
{
    // Napravite skriptu koja u sebi ima varijablu "health".
    // Kada cube dira sferu neka gubi health za 5 po sekundi.

    public float health = 100;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sfera"))
        {
            health -= 5 * Time.deltaTime;
        }
    }
}
