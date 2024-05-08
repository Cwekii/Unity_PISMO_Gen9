using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak1_4 : MonoBehaviour
{
    // Napisite skriptu za zakljucavanje rotacije po z osi te kretanja po 
    // Y osi


    Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ ;

    }
}
