using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void exit()
    {
        Debug.Log("Izašao sam!");
        Application.Quit();
    }

 
}
