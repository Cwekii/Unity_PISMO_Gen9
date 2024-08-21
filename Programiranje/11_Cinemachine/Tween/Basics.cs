using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basics : MonoBehaviour
{
    [SerializeField] Transform[] cubes;
    [SerializeField] Transform camera;
    [SerializeField] Light light;

    // Start is called before the first frame update
    void Start()
    {
        //var sequence = DOTween.Sequence();
        //foreach (Transform cube in cubes)
        //{
        //    sequence.Append(cube.DOScale(new Vector3(Random.Range(0.2f, 2f), Random.Range(0.2f, 2f),
        //        Random.Range(0.2f, 2f)), 2).OnComplete()) => {

        //    } }; 

        //}

        cubes[1].DOMove(new Vector3(5, 0, 0), 2.5f).SetEase(Ease.OutElastic).OnComplete(() =>
        {

        });
        camera.DOShakeRotation(0.7f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            camera.DOShakePosition(0.3f, 0.5f, 10, 100);
            camera.DOShakeRotation(0.4f, 10, 10, 30);

        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            light.DOIntensity(20, 10f).SetEase(Ease.InOutBounce);
        }
    }

    private void Banana()
    {
            
    }


}
