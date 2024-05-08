using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{

    Rigidbody rigidbody;
    public float walkSpeed;
    public float runSpeed;

    private void Awake()
    {
       rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 movingDirection = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.useGravity = false;
            rigidbody.velocity = Vector3.zero;
        }

        //if (Input.GetKey(KeyCode.A))
        //{
        //    //rigidbody.velocity += Vector3.left;

        //}
        
        if (Input.GetKey(KeyCode.W))
        {
            //rigidbody.velocity += Vector3.left;
            movingDirection += Vector3.forward;
        }
        
        if (Input.GetKey(KeyCode.A))
        { 
            //rigidbody.velocity = Vector3.zero;
            movingDirection += Vector3.left;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            //rigidbody.velocity += Vector3.right;
            movingDirection += Vector3.right;
        } 
        
        if (Input.GetKey(KeyCode.S))
        {
            //rigidbody.velocity += Vector3.right;
            movingDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(movingDirection * runSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(movingDirection * walkSpeed * Time.deltaTime);

        }

        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    rigidbody.velocity = Vector3.zero;
        //}

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rigidbody.velocity = Vector3.zero;
        }
        
        if (collision.gameObject.CompareTag("Kocka"))
        {
            collision.transform.position += Vector3.left * 3;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sfera"))
        {
            collision.transform.position -= Vector3.up * 2;
        }

        if (collision.gameObject.CompareTag("Kocka"))
        {
            collision.transform.position -= Vector3.left * 3;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        Debug.Log("U vatri sam!! aaaaaaaa");
    }
}
