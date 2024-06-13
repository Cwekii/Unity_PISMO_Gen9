using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collect : MonoBehaviour
{
    public Text scoreText; // Varijabla za UI element (text) koji �e prikazivati trenunti rezultat
    int scoreCurrent; // Varijabla za trenutni rezultat igra�a
    int scoreMax; // Varijabla za maksimalni rezultat, tj. max broj objekata koje treba skupiti
    GameObject[] objekti; // Niz objekata koji trebaju biti sakupljeni (tagirani kao Coin)
    public GameObject endGamePanel; //Panel koji se prikazuje na kraju igre
    public Text result; // tekst koji �e prikazivati rezultat na kraju igre
    public Text endText; // tekst koji prikazuje poruku o zavr�etku igre
    public Timer tm; // refrenca na Timer skriptu

    private void Start()
    {
        endGamePanel.SetActive(false); // sakriva panel za kraj igre na po�etku
        objekti = GameObject.FindGameObjectsWithTag("Coin"); // Pronalazi sve objekete u sceni 
                                                             // sa tagom coin
        scoreMax = objekti.Length; // Postavljamo maksimalni rezultat na broj objekata
        scoreText.text = scoreCurrent + "/" + scoreMax; // A�uriramo tekst prikazuju�i trenutni 
                                                        // i maksimalni rezultat

        tm = FindObjectOfType<Timer>(); // Pronalazimo instancu timer skripte u sceni

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin") // Provjerava je li drugi objekt tagiran kao Coin
        {
            scoreCurrent++; // Pove�avamo trenutni rezultat za 1
            Destroy(other.gameObject);// Uni�tava sakupljeni objekt
            scoreText.text = scoreCurrent + "/" + scoreMax; // A�urira prikaz rezultata
            if (scoreCurrent == scoreMax) // provjeravamo je li trenutni rezultat jednak maksimalnom
            {
                //postavljamo rezultat na temelju preostalog vremena
                result.text = ((int)(scoreMax * tm.allTime)).ToString();
                endText.text = "YOU WIN! YOUR SCORE IS: "; // Postavljamo zavr�nu poruku
                endGamePanel.SetActive(true); // prikazujemo panel za kraj igre
                Time.timeScale = 0f;
            }
        }
    }

    public void Lose() // metoda koja se poziva kada igra� izgubi
    {
        //postavlja rezultat temeljen na broju skupljenih objekata
        result.text = ((int)(scoreCurrent * 10)).ToString();
        endText.text = "YOU LOSE! YOUR SCORE IS : "; // Postavljamo zavr�nu poruku
        endGamePanel.SetActive(true);//prikazujemo panel za kraj
        Time.timeScale = 0f;
    }
}
