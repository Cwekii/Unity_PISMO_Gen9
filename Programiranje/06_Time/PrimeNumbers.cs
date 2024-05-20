using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeNumbers : MonoBehaviour
{

    private void Start()
    {
        for (int i = 100; i > 0; i--)
        {
            
            if (isPrime(i))
            {
                Debug.Log(i);
            }
        }
    }

    bool isPrime(int number)
    {
        for (int i = 2;i <= number / 2;i++)
        {
            if(number % i == 0)
            {
                return false;
            }

        }

        return true;
    }
}
