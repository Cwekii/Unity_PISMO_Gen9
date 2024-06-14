using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints; //Radimo array koji æe sadržavati pozicije na kojima æe se 
                                    //enemy pojavljivati
    public GameObject[] enemies; // Radimo array koji æe sadržavati razlièite tipove enemya koji
                                 // æe se pojavljivati u igri

    public GameObject[] weapons; // Radimo array koji æe sadržavati razlièita oružja koja igraè
                                 // može koristiti

    public int killCount; // varijabla koja prati broj ubijenih enemya

    void SpawnEnemy()
    {
        int randomSpawnPoint = Random.Range(0,spawnPoints.Length);// generiramo nasumièni indeks
                                                                 // za poziciju spawn pointa
        int randomEnemy = Random.Range(0,enemies.Length);// generiramo nasumièni indeks za enemy

        //stvaramo nasumiènog enemya na nasumiènoj poziciji sa osnovnom rotacijom
        Instantiate(enemies[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }

    // metoda pomoæu koje æemo mijenjati aktivno oružje
    void SwitchWeapon(int indexActive)
    {
        for (int i = 0; i< weapons.Length; i++) //petlja prolazi kroz sva oružja i stavlja ih da
                                                //su neaktivna
        {
            weapons[i].SetActive(false);
        }
        weapons[indexActive].SetActive(true); // aktivira oružje èiji je ineks indexActive
    }

    //DETALJNO POJAŠNJENJE PETLJE : 
    //Znaèi petlja prolazi kroz sve elemente niza weapons
    //Nakon svakog prolaska petlje poveæamo za 1 (i++)
    //weapons[i].SetActive(false)
    //Unutar petlje, svaki element niza weapons postavljamo na neaktivan koristeæi SetActive(false)
    //weapons[i] Pristuamo svakom oružju u nizu putem indeksa i
    //SetActive(false) ova metoda deaktivira oružje, èineæi ga nevidljivim i nedostupnim u igri
    //Na kraju pristupamo oružju koje želimo aktivirati koristeæi indexActive

    private void Update()
    {
        // provjeravamo je li stisnuta tipka 1 ako je aktiviramo prvo oružje
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            SwitchWeapon(0);
        }

        // provjeravamo je li stisnuta tipka 2 ako je aktiviramo drugo oružje
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            SwitchWeapon(1);
        }

        // provjeravamo je li stisnuta tipka 3 ako je aktiviramo trece oružje
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            SwitchWeapon(2);
        }

        // provjeravamo je li stisnuta tipka 4 ako je aktiviramo cetvrto oružje
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

        //prvo oružje u nizu postavljamo na true tj da bude vidljivo
        weapons[0].SetActive(true);
    }
}
