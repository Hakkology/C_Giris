using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMap : MonoBehaviour
{
    public int width = 30;
    public int depth = 30;
    public float noiseScale = 0.12f;
    public int scale = 2;
    public int maxHeight = 8;

    void Start()
    {
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                float nx = x * noiseScale;
                float nz = z * noiseScale;
                float noise = Mathf.PerlinNoise(nx, nz);

                int height = Mathf.RoundToInt(noise * maxHeight);

                Color color;

                if (noise < 0.3f)
                {
                    color = Color.blue;
                    height = 1;
                }
                else if (noise < 0.4f)
                {
                    color = new Color(0.8f, 1f, 0.6f);
                }
                else if (noise < 0.7f)
                {
                    color = new Color(0.1f, 0.5f, 0.1f);
                }
                else
                {
                    color = new Color(0.4f, 0.3f, 0.15f);
                    height += 2;
                }

                for (int y = 0; y < height; y++)
                {
                    Vector3 pos = new Vector3(x * scale, y * scale, z * scale);
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = pos;
                    cube.transform.localScale = new Vector3(scale, scale, scale);
                    cube.GetComponent<Renderer>().material.color = color;
                }
            }
    }
}
