using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{
    //ova sekcija slu�i za municiju
    [Header("Ammo")]
    public int maxAmmo; // maksimalan broj metaka koje oru�je mo�e imati
    int currentAmmo; // trenutni broj metaka u oru�ju
    public Text ammoText; // tekst za prikaz broja metaka na ekranu

    //ova sekcija slu�i za osnovne informacije o oru�ju
    [Header("About a weapon")]
    public float fireRate; // Minimalno vrijeme izme�u dva ispaljena metka
    float fireRateRestart; // vrijeme izme�u metka koji se resetira nakon pucnja
    public float accuracy;// preciznost oru�ja u pikselima
    public float reloadTime;// vrijeme potrebno za promjenu �an�era
    float reloadTimeRestart; // vrijeme za ponovno punjenje �an�era koje se resetira
    public Camera mainCamera; // Glavna kamera igre
    public Camera scopeCamera; // Kamera za ni�an

    //ova sekcija slu�i za informacije o metku
    [Header("Bullet info")]
    public Rigidbody bulletPrefab; // prefab metka koji se ispaljuje
    public Transform bulletSpawnPosition; // pozicija iz koje se ispaljuje metak (cijev pu�ke)


    //ova sekcija slu�i za na�in pucanja
    [Header("Fire mode : * Single fire mode je default")]
    public bool singleFire = true; // postavka za jednokratno pucanje
    public bool automaticFire = false; // postavka za automatsko pucanje
    public bool burstFire = false; // postavke za burst pucanje (tri po tri metka)





}
