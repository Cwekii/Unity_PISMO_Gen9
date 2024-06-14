using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints; //Radimo array koji �e sadr�avati pozicije na kojima �e se 
                                    //enemy pojavljivati
    public GameObject[] enemies; // Radimo array koji �e sadr�avati razli�ite tipove enemya koji
                                 // �e se pojavljivati u igri

    public GameObject[] weapons; // Radimo array koji �e sadr�avati razli�ita oru�ja koja igra�
                                 // mo�e koristiti

    public int killCount; // varijabla koja prati broj ubijenih enemya

    void SpawnEnemy()
    {
        int randomSpawnPoint = Random.Range(0,spawnPoints.Length);// generiramo nasumi�ni indeks
                                                                 // za poziciju spawn pointa
        int randomEnemy = Random.Range(0,enemies.Length);// generiramo nasumi�ni indeks za enemy

        //stvaramo nasumi�nog enemya na nasumi�noj poziciji sa osnovnom rotacijom
        Instantiate(enemies[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }

    // metoda pomo�u koje �emo mijenjati aktivno oru�je
    void SwitchWeapon(int indexActive)
    {
        for (int i = 0; i< weapons.Length; i++) //petlja prolazi kroz sva oru�ja i stavlja ih da
                                                //su neaktivna
        {
            weapons[i].SetActive(false);
        }
        weapons[indexActive].SetActive(true); // aktivira oru�je �iji je ineks indexActive
    }

    //DETALJNO POJA�NJENJE PETLJE : 
    //Zna�i petlja prolazi kroz sve elemente niza weapons
    //Nakon svakog prolaska petlje pove�amo za 1 (i++)
    //weapons[i].SetActive(false)
    //Unutar petlje, svaki element niza weapons postavljamo na neaktivan koriste�i SetActive(false)
    //weapons[i] Pristuamo svakom oru�ju u nizu putem indeksa i
    //SetActive(false) ova metoda deaktivira oru�je, �ine�i ga nevidljivim i nedostupnim u igri
    //Na kraju pristupamo oru�ju koje �elimo aktivirati koriste�i indexActive

    private void Update()
    {
        // provjeravamo je li stisnuta tipka 1 ako je aktiviramo prvo oru�je
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            SwitchWeapon(0);
        }

        // provjeravamo je li stisnuta tipka 2 ako je aktiviramo drugo oru�je
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            SwitchWeapon(1);
        }

        // provjeravamo je li stisnuta tipka 3 ako je aktiviramo trece oru�je
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            SwitchWeapon(2);
        }

        // provjeravamo je li stisnuta tipka 4 ako je aktiviramo cetvrto oru�je
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            SwitchWeapon(3);
        }
    }

    private void Start()
    {
        // Pozivamo metodu spawn enemy odmah i zatim ponavljamo svake 3 sekunde
        InvokeRepeating("SpawnEnemy", 0, 3);

        //Ova petlja prolazi kroz sva oruzja i postavlja ih na neaktivna tj skriva ih
        for (int i = 0; i< weapons.Length;i++)
        {
            weapons[i].SetActive(false) ;
        }

        //prvo oru�je u nizu postavljamo na true tj da bude vidljivo
        weapons[0].SetActive(true);
    }
}
