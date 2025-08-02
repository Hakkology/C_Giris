using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Labirent : MonoBehaviour
{
    public int width = 30;
    public int depth = 30;
    public int scale = 6;

    public byte[,] harita;

    private void Start()
    {
        HaritayiBelirle(); // hepsine 1 ver.
        HaritayiOlustur(); // 1 0 karar ver
        HaritayiCiz(); // 1 se küp koy
    }

    private void HaritayiBelirle()
    {
        harita = new byte[width, depth];

        for (int x = 0; x < depth; x++)
        {
            // her satýrý dönüyor.
            for (int z = 0; z < width; z++)
            {
                // o satýr içindeki tüm kolonu tek tek dönecek.
                harita[x, z] = 1;
            }
        }
    }

    protected virtual void HaritayiOlustur()
    {
        for (int x = 0; x < depth; x++)
        {
            for (int z = 0; z < width; z++)
            {
                if (Random.Range(0, 100) <50)
                {
                    harita[x, z] = 0;
                }
            }
        }
    }

    private void HaritayiCiz()
    {
        for (int x = 0; x < depth; x++)
        {
            for (int z = 0; z < width; z++)
            {
                if (harita[x,z] == 1)
                {
                    Vector3 konum = new Vector3(scale *x, 0, scale*z);
                    GameObject duvar = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    duvar.transform.localScale = new Vector3(scale, scale, scale);
                    duvar.transform.position = konum;
                }
            }
        }
    }

}
