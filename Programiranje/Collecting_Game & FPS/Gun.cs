using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{
    //ova sekcija služi za municiju
    [Header("Ammo")]
    public int maxAmmo; // maksimalan broj metaka koje oružje može imati
    int currentAmmo; // trenutni broj metaka u oružju
    public Text ammoText; // tekst za prikaz broja metaka na ekranu

    //ova sekcija služi za osnovne informacije o oružju
    [Header("About a weapon")]
    public float fireRate; // Minimalno vrijeme izmeðu dva ispaljena metka
    float fireRateRestart; // vrijeme izmeðu metka koji se resetira nakon pucnja
    public float accuracy;// preciznost oružja u pikselima
    public float reloadTime;// vrijeme potrebno za promjenu šanžera
    float reloadTimeRestart; // vrijeme za ponovno punjenje šanžera koje se resetira
    public Camera mainCamera; // Glavna kamera igre
    public Camera scopeCamera; // Kamera za nišan

    //ova sekcija služi za informacije o metku
    [Header("Bullet info")]
    public Rigidbody bulletPrefab; // prefab metka koji se ispaljuje
    public Transform bulletSpawnPosition; // pozicija iz koje se ispaljuje metak (cijev puške)


    //ova sekcija služi za naèin pucanja
    [Header("Fire mode : * Single fire mode je default")]
    public bool singleFire = true; // postavka za jednokratno pucanje
    public bool automaticFire = false; // postavka za automatsko pucanje
    public bool burstFire = false; // postavke za burst pucanje (tri po tri metka)





}
