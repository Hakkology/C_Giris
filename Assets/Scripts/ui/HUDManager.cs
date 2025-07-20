using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI canMetin;
    //public TextMeshProUGUI enerjiMetin;
    public TextMeshProUGUI kursunMetin;

    public Slider enerjiSlider;
    public Slider timeSlider;

    private float maxSure = 15f;
    private float mevcutSure;

    private void Start()
    {
        UpdateCanMetin("100");

        enerjiSlider.maxValue = 100;
        enerjiSlider.value = enerjiSlider.maxValue;

        mevcutSure = maxSure;
        timeSlider.maxValue = maxSure;
        timeSlider.value = timeSlider.maxValue;
        //UpdateEnerjiMetin("100");
        //UpdateKursunMetin("100");


    }

    private void Update()
    {
        mevcutSure -= Time.deltaTime;
        timeSlider.value = mevcutSure;
    }

    public void UpdateCanMetin(string metin)
    {
        canMetin.text = "Can: " + metin;
    }

    public void UpdateKursunMetin(string metin)
    {
        kursunMetin.text = "Ammo: " + metin;
    }

    public void UpdateEnerjiMetin(float enerji)
    {
        enerjiSlider.value = enerji;
    }

}
