using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Koridor : Labirent
{
    public int yatayKoridor = 3;
    public int dikeyKoridor = 2;


    protected override void HaritayiOlustur()
    {
        //base.HaritayiOlustur();

        for (int i = 0; i < yatayKoridor; i++)
            YatayKoridorCiz();

        for (int i = 0; i < dikeyKoridor; i++)
            DikeyKoridorCiz();

    }

    void DikeyKoridorCiz()
    {
        bool bittimi = false;
        int x = Random.Range(1, width - 1);
        int z = 1;

        while (!bittimi)
        {
            harita[x, z] = 0;
            if (Random.Range(0, 100) < 50)
                x += Random.Range(-1, 2);
            else
                z += Random.Range(0, 2);
            bittimi |= (x < 1 || x >= width - 1 || z < 1 || z >= depth - 1);
        }
    }

    void YatayKoridorCiz()
    {
        bool bittimi = false;
        int x = 1;
        int z = Random.Range(1, depth - 1);

        while (!bittimi)
        {
            harita[x, z] = 0;
            if (Random.Range(0, 100) < 50)
                x += Random.Range(0, 2);
            else
                z += Random.Range(-1, 2);
            bittimi |= (x < 1 || x >= width - 2 || z < 1 || z >= depth - 2);
        }
    }
}
