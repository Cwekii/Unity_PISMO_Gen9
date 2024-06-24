using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class Korutine : MonoBehaviour
{

    
    
    [SerializeField] List<GameObject> images;
    [SerializeField] List<Color> colors;

    [SerializeField] bool isGameOver;
    [SerializeField]
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].SetActive(false);
        }

        StartCoroutine(ActivateImages());
    }

    IEnumerator ActivateImages()
    {
       while (!isGameOver)
        {
            for (int i = 0; i < images.Count; i++)
            {
                yield return new WaitForSeconds(0.7f);
                images[i].SetActive(true);
                GameObject child = new GameObject(images[i].name);
                child.transform.parent = images[i].transform;
                yield return new WaitForSeconds(0.3f);
                child.AddComponent<TextMeshProUGUI>();
                TextMeshProUGUI tmpText = child.GetComponent<TextMeshProUGUI>();
                tmpText.text = i.ToString();
                tmpText.color = colors[i];
            }
        }
    }




}
