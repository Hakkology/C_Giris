using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class Unity55 : MonoBehaviour
{
    int selam = 3;
    bool kral = false;
    bool cutsceneMode = false;
    bool multiplayerMode = false;

    bool ondenCarpma;
    bool arkadanCarpma;
    bool yandanCarpma;

    bool ikiliCarpma;

    // Start is called before the first frame update
    void Start()
    {
        if (cutsceneMode == false)
        {
            
        }

        if (multiplayerMode == false)
        {
            // yapay zekalarý çalýþtýr
        }
        else
        {
            // oyuncularý baðlan
        }


        //if (ikiliCarpma == true)
        //{
        //    // iki arayabada hasar ver
        //    // birinci arabada:
        //    if (ondenCarpma == true)
        //    {
        //        // ön tarafa hasar ver
        //    }
        //    else if (arkadanCarpma == true)
        //    {
        //        // arka tarafa hasar ver
        //    }
        //    else if (yandanCarpma == true)
        //    {
        //        // yan tarafa hasar ver
        //    }
        //},

        int ahmet = 0;

        //if (ahmet < 10 && ahmet >5)
        //{
            
        //}

        //if (ahmet < 10 || ahmet > 5)
        //{

        //}

        while (ahmet < 10)
        {
            // update 
            //ahmet = ahmet + 1;
            ahmet++;
            Debug.Log(ahmet);
        }

        for(int hasan = 0; hasan<10; hasan++)
        {
            ahmet++;
            Debug.Log(ahmet);
        }

        // selamin aleyküm
        int selam = 3;
        int naber = 4;
        int nasilsin = naber;

        Debug.Log(selam);
        Debug.Log(naber);
        
        Debug.Log(nasilsin);

        //Debug.Log(selam * naber);
        //Debug.Log(selam + naber);

        int carpim = selam * naber;
        int toplam = selam + naber;
        Debug.Log(carpim * toplam);
        Debug.Log((carpim * toplam) * (carpim + toplam));

        string unity55 = "Unity 55 en kral sýnýf";
        string unity55degiskenli = $"Unity {carpim} en kral sýnýf";
        Debug.Log(unity55);
        Debug.Log(unity55degiskenli);

        float kral = 12.5f;
        float krall = 15f;
        int kralll = 15;

        double bar = 25.56d;
        decimal baz = 353.25m;

        bool emre = false;
        bool kralllll = true;

        int sayi = 15;

        if (sayi < 10)
        {
            //ya bu
            // kýrmýzý durumu
            
        }
        else if ( sayi > 20) 
        {
            // ya bu
            // sarý durumu
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (cutsceneMode == true)
        {
            return;
        }
        // temel döngü
        //int selam = 3;
        //Debug.Log(selam);

        // karakter hareket kodu
    }
}
