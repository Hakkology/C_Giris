using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int hiz;
    public int yurumeHizi = 4;
    public int kosmaHizi = 7;

    public int skor = 0;

    private int can = 100; // Oyuncunun can�
    private float enerji = 100; // Oyuncunun can�

    private Rigidbody rb; // referans
    private SphereCollider scoll; // referans


    private bool havalardayim = false;
    private bool birkezvurdun = false;

    //private bool kosuyormuyum = false;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        scoll = GetComponent<SphereCollider>();

        //SphereCollider scoll2 = gameObject.AddComponent<SphereCollider>();
    }
    void Start()
    {
        //rb = GetComponent<Rigidbody>(); 
        //rb = gameObject.GetComponent<Rigidbody>();
        //rb.useGravity = false;
        //scoll.isTrigger
    }

    // Update is called once per frame
    void Update()
    {
        Kosma(); // Ko�ma fonksiyonunu �a��r
        Hareket(); // Hareket fonksiyonunu �a��r
        Zipla(); // Z�plama fonksiyonunu �a��r
    }

    private void Zipla()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !havalardayim)
        {
            havalardayim = true;
            //transform.position += new Vector3(0, 5, 0);
            //transform.Translate(0, 5, 0);
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }

        //if (transform.position.y < 1)
        //{
        //    havalardayim = false; 
        //}
    }

    private void Hareket()
    {
        // Kullan�c� giri�iyle hareket
        float xHareket = Input.GetAxis("Horizontal") * hiz * Time.deltaTime;
        float zHareket = Input.GetAxis("Vertical") * hiz * Time.deltaTime;

        transform.Translate(new Vector3(xHareket, 0, zHareket));
    }

    void Kosma() 
    {
        //bool kosuyormuyum = false;
        hiz = yurumeHizi;
        enerji += 10 * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift) && enerji > 0)
        {
            //kosuyormuyum = true;
            hiz = kosmaHizi;
            enerji -= 30 * Time.deltaTime;
        }
    }

    void HasarVer(string nereyeDogru)
    {         // Hasar verme i�lemleri
        if (nereyeDogru == "Omuz")
        {
            Debug.Log("Omuza hasar verildi.");
        }
        else if (nereyeDogru == "Kafaya")
        {
            Debug.Log("Kafaya hasar verildi.");
        }
        else if (nereyeDogru == "On")
        {
            Debug.Log("�ne hasar verildi.");
        }
        else if (nereyeDogru == "Arka")
        {
            Debug.Log("Arkaya hasar verildi.");
        }

        switch (nereyeDogru) 
        {
            case "Omuz":
                Debug.Log("Omuza hasar verildi.");
                break;
            case "Kafaya":
                Debug.Log("Kafaya hasar verildi.");
                break;
            case "On":
                Debug.Log("�ne hasar verildi.");
                break;
            case "Arka":
                Debug.Log("Arkaya hasar verildi.");
                break;
        }
    }

    void Sald�rmaYonetici()
    {
        if (birkezvurdun)
        {
            can -= 20;
            birkezvurdun = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Yer")
        {
            havalardayim = false;
        }
    }

    public void SkorArtir(int eklenenskor)
    {
        skor += eklenenskor;
        Debug.Log(skor);
    }

    //void StaminaYonetici()
    //{
    //    if (kosuyormuyum)
    //    {

    //    }
    //}

    void Rastgele()
    {
        // S�rekli kuvvet
        rb.AddForce(Vector3.forward * 5, ForceMode.Force);

        // Ani kuvvet (yumruk etkisi gibi)
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        // K�tleden ba��ms�z h�z de�i�imi
        rb.AddForce(Vector3.right * 5, ForceMode.VelocityChange);
    }


}

