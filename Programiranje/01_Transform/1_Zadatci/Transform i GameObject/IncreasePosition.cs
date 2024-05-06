using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePosition : MonoBehaviour
{
    //kad god se upali kocka neka se poveca pozicija za 1,1,1 a kocka neka se pali i gasi svaki frame

    private void OnEnable()
    {
        transform.position += new Vector3(1,1,1);
        
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
