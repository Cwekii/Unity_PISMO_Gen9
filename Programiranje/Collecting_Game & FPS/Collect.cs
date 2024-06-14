using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collect : MonoBehaviour
{
    public Text scoreText; // Varijabla za UI element (text) koji æe prikazivati trenunti rezultat
    int scoreCurrent; // Varijabla za trenutni rezultat igraèa
    int scoreMax; // Varijabla za maksimalni rezultat, tj. max broj objekata koje treba skupiti
    GameObject[] objekti; // Niz objekata koji trebaju biti sakupljeni (tagirani kao Coin)
    public GameObject endGamePanel; //Panel koji se prikazuje na kraju igre
    public Text result; // tekst koji æe prikazivati rezultat na kraju igre
    public Text endText; // tekst koji prikazuje poruku o završetku igre
    public Timer tm; // refrenca na Timer skriptu

    private void Start()
    {
        endGamePanel.SetActive(false); // sakriva panel za kraj igre na poèetku
        objekti = GameObject.FindGameObjectsWithTag("Coin"); // Pronalazi sve objekete u sceni 
                                                             // sa tagom coin
        scoreMax = objekti.Length; // Postavljamo maksimalni rezultat na broj objekata
        scoreText.text = scoreCurrent + "/" + scoreMax; // Ažuriramo tekst prikazujuæi trenutni 
                                                        // i maksimalni rezultat

        tm = FindObjectOfType<Timer>(); // Pronalazimo instancu timer skripte u sceni

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin") // Provjerava je li drugi objekt tagiran kao Coin
        {
            scoreCurrent++; // Poveæavamo trenutni rezultat za 1
            Destroy(other.gameObject);// Uništava sakupljeni objekt
            scoreText.text = scoreCurrent + "/" + scoreMax; // Ažurira prikaz rezultata
            if (scoreCurrent == scoreMax) // provjeravamo je li trenutni rezultat jednak maksimalnom
            {
                //postavljamo rezultat na temelju preostalog vremena
                result.text = ((int)(scoreMax * tm.allTime)).ToString();
                endText.text = "YOU WIN! YOUR SCORE IS: "; // Postavljamo završnu poruku
                endGamePanel.SetActive(true); // prikazujemo panel za kraj igre
                Time.timeScale = 0f;
            }
        }
    }

    public void Lose() // metoda koja se poziva kada igraè izgubi
    {
        //postavlja rezultat temeljen na broju skupljenih objekata
        result.text = ((int)(scoreCurrent * 10)).ToString();
        endText.text = "YOU LOSE! YOUR SCORE IS : "; // Postavljamo završnu poruku
        endGamePanel.SetActive(true);//prikazujemo panel za kraj
        Time.timeScale = 0f;
    }
}
