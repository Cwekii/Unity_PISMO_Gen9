using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbody1_4 : MonoBehaviour
{
    // Napravite skriptu gdje se prilikom pokupljenog novcica score poveca
    // za 1 te novcic bude set active false

    public GameObject sfera;
    public float score;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sfera")
        {
            other.gameObject.SetActive(false);
            //sfera.SetActive(false);
            score++;
            Debug.Log(score);
        }
    }
}
