using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatk1_6 : MonoBehaviour
{
    // Napisite skriptu za silu eksplozije

    Rigidbody rb;
    public float explosionForce;
    public Vector3 explosionPosition;
    public float upwardModifier;
    public ForceMode forceMode;
    public float radius = 5.0F;
    public float power = 10.0F;

    void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(explosionForce, explosionPos, 0, 3.0F);
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Vector3 explosionPos = transform.position;
        //    Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
           
        //    foreach (Collider hit in colliders)
        //    {
        //        Rigidbody rb = hit.GetComponent<Rigidbody>();

        //        if (rb != null)
        //        {
        //            rb.AddExplosionForce(explosionForce, explosionPos,
        //            radius, upwardModifier, forceMode);


        //        }
        //    }
            
        //}
    }
}
