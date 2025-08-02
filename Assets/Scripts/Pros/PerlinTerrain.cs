using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTerrain : MonoBehaviour
{
    public int width = 30;
    public int depth = 30;
    public int maxHeight = 6;
    public int scale = 2;

    public float noiseScale = 0.2f;

    public Transform Cevre;

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                float noise = Mathf.PerlinNoise(x * noiseScale, z * noiseScale);
                int height = Mathf.RoundToInt(noise * maxHeight);

                for (int y = 0; y < height; y++)
                {
                    Vector3 konum = new Vector3(scale * x, scale * y, scale * z);
                    GameObject duvar = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    duvar.transform.localScale = new Vector3(scale, scale, scale);
                    duvar.transform.position = konum;
                }
            }
        }
    }
}
