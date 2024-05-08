using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak1_5 : MonoBehaviour
{
    /*
     Skripta za zakljucavanje rotacije po x osi te kretanja po x i y osi,
    a na klik tipke U otkljucajte po svim osima sve ( rotaciju i kretanje)
    a na klik tipke F zakljucajte po svim osima kretanje
     */

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            rb.constraints = RigidbodyConstraints.None;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
}
