using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListeDizi : MonoBehaviour
{
    int[] sayilar = new int[5];
    List<int> sayilarList = new List<int>();

    public GameObject hedefReferans;

    // Start is called before the first frame update
    void Start()
    {
        sayilar[0] = 0;
        sayilar[1] = 1;
        sayilar[2] = 2;
        sayilar[3] = 3;
        sayilar[4] = 4;
        //sayilar[5] = 5;
        sayilar[2] = 7;

        int denemeSayi = sayilar[0];

        for (int i = 0; i < sayilar.Length; i++)
        {
            Debug.Log(sayilar[i]);
        }

        //List 
        sayilarList.Add(10);
        sayilarList.Add(20);
        sayilarList.Add(30);
        //sayilarList.Add();

        int n = sayilarList.Count;

        for (int i = 0; i < n; i++)
        {
            Debug.Log(sayilarList[i]);
        }
        //var item
        foreach (int sayi in sayilar)
        {
            
        }

        //TekilDuzen.Instance.skor = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
