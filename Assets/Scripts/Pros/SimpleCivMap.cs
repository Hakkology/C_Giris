using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCivMap : MonoBehaviour
{
    public int width = 30;
    public int depth = 30;
    public float noiseScale = 0.12f;
    public int scale = 2;
    public int maxHeight = 8;
    public int quantizeBands = 4;

    // �nceki olu�turulan bloklar� silmek i�in tutulacak parent
    public Transform mapParent;

    private void Start()
    {
        Generate();
    }

    // Haritay� olu�turur
    public void Generate()
    {
        // Eski haritay� temizle
        if (mapParent != null)
        {
            foreach (Transform child in mapParent)
                DestroyImmediate(child.gameObject);
        }
        else
        {
            // Yoksa otomatik olu�tur
            GameObject parentObj = new GameObject("MapParent");
            parentObj.transform.SetParent(this.transform);
            mapParent = parentObj.transform;
        }

        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                float nx = x * noiseScale;
                float nz = z * noiseScale;
                float noise = Mathf.PerlinNoise(nx, nz);

                // Quantize i�lemi: d�z bloklar ve biyom s�n�rlar�
                float quant = Mathf.Floor(noise * quantizeBands) / quantizeBands;

                int height = Mathf.RoundToInt(quant * maxHeight);

                Color color;

                if (quant < 0.25f)
                {
                    color = Color.blue; // Su
                    height = 1;
                }
                else if (quant < 0.5f)
                {
                    color = new Color(0.8f, 1f, 0.6f); // Ova
                }
                else if (quant < 0.75f)
                {
                    color = new Color(0.1f, 0.5f, 0.1f); // Orman
                }
                else
                {
                    color = new Color(0.4f, 0.3f, 0.15f); // Da�
                    height += 2;
                }

                // Bloklar� olu�tur
                for (int y = 0; y < height; y++)
                {
                    Vector3 pos = new Vector3(x * scale, y * scale, z * scale);
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = pos;
                    cube.transform.localScale = new Vector3(scale, scale, scale);
                    cube.GetComponent<Renderer>().material.color = color;
                    cube.transform.SetParent(mapParent);
                }
            }
        }
    }
}