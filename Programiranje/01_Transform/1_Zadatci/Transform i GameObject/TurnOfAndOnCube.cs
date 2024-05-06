using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOfAndOnCube : MonoBehaviour
{
    public GameObject Cube;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isActive = !isActive;

        if (isActive)
        {
            Cube.SetActive(false);
        }

        else
        {
            Cube.SetActive(true);
        }

        
    }
}
