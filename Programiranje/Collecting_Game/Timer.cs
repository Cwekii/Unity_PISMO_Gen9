using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText; // Prikaz teksta vremena
    [Range(0, 59)] // atribut koji nam osigurava da se vrijeme može postaviti od 0 do 59 za minute
    public int timeCountMinutes = 5; // Unešena vrijednost u minutama od koliko krecemo npe 5.
                                     // imamo 5 minuta za skupiti sfere
    [Range(0, 59)] //atribut koji nam osigurava da se vrijeme može postaviti od 0 do 59 za sekunde
    public int timeCountSeconds;
    public float allTime; // ukupno vrijeme u sekundama
    public Collect ct; // referenca na collect skriptu, stavljamu ju jer æemo pozivti Lose metodu iz nje


    private void Start()
    {
        ct = FindObjectOfType<Collect>(); // pronalazi instancu skripte collect i stavlja ju u variablu ct
        timeCountMinutes *= 60; // minute pretvaramo u sekunde (1 minuta = 60 sekundi)
        allTime = timeCountMinutes + timeCountSeconds; // minute i sekunde zbrajamo

    }

    private void Update()
    {
        if(allTime >0) // prvo provjeravamo je li preostalo vrijeme veæe od nula
        {
            allTime -= Time.deltaTime; // oduzimamo proteklo vrijeme (u sekundama) od ukupnog
            //vremena. Time.deltaTime je proteklo vrijeme izmeðu dva frame-a, tako osiguravamo da
            // tajmer smanjuje u realnome vremenu
            int minutes = (int)(allTime / 60); // dijelimo sa cijelim brojem 60 da dobijemo minute
            // rezultat je cijelobrojno dijeljenje npr 125/60 = 2
            int secounds = Mathf.FloorToInt(allTime % 60); // dijelimo sa 60 da dobijemo ostatak kako
            //bismo dobili sekunde. znaèi koristimo % da bi dobili ostatak. Mathf.FlootoInt nam služi
            //da zaokruži decimalnu vrijednost na najbliži broj tipa kad bi ostatak bio 5.1245 dobili bi 5
            
            //ako su minute i sekunde manje od 10, znaèi ako su obije vrijednosti manje od 10 
            //dodajemo 0 ispred
            if(minutes <10 && secounds < 10)
            {
                timerText.text = "0" + minutes + ":" + "0" + secounds;
            }

            // ako su minute jednoznamenkaste a sekunde dvoznamenkaste
            else if(minutes < 10 && secounds >= 10)
            {
                timerText.text = "0" + minutes + ":" + secounds;
            }

            //Minute su dvoznamenkaste, ali sekunde su jednoznamenkaste
            else if (minutes >=10 && secounds < 10)
            {
                timerText.text = minutes + ":0" + secounds;
            }

            //Minute i sekunde su nam dvoznamenkaste
            else
            {
                timerText.text = minutes + ":" + secounds;
            }
        }
        else
        {
            ct.Lose(); // ako time padne ispod 0 pozivamo metodu iz Collect skripte
        }

    
    }


}
