using UnityEngine;
// Basit procedural cave (maðara) algoritmasý.
// Cellular automata ile maðara benzeri bir yapý üretir.
public class MagaraTerrain : MonoBehaviour
{
    public int width = 40;          // Haritanýn geniþliði (x)
    public int depth = 40;          // Haritanýn derinliði (z)
    public int scale = 2;           // Her küpün boyutu
    public int fillPercent = 45;    // Baþlangýçta % kaç hücre duvar olacak?
    public int smoothSteps = 5;     // Kaç kere pürüzsüzleþtirilecek (iteration)?

    byte[,] map;                    // Maðara haritasý (0 = zemin, 1 = duvar)

    void Start()
    {
        map = new byte[width, depth];

        // 1) Haritayý rastgele doldur (duvar ve zemin)
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
                // fillPercent'e göre rastgele 1 (duvar) veya 0 (zemin) ata
                map[x, z] = (byte)(Random.Range(0, 100) < fillPercent ? 1 : 0);

        // 2) Cellular Automata ile maðarayý pürüzsüzleþtir
        for (int step = 0; step < smoothSteps; step++)
        {
            byte[,] newMap = new byte[width, depth];

            for (int z = 0; z < depth; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    int wallCount = 0; // Komþu hücrelerde kaç duvar var?

                    // 3x3 komþuluk kontrolü (kendisi dahil)
                    for (int dz = -1; dz <= 1; dz++)
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            int nx = x + dx, nz = z + dz;
                            // Sýnýr dýþý ise, duvar gibi say (kapanma saðlanýr)
                            if (nx < 0 || nz < 0 || nx >= width || nz >= depth)
                                wallCount++;
                            else if (map[nx, nz] == 1)
                                wallCount++;
                        }
                    // 5 ve üzeri komþuda duvar varsa, burasý duvar olsun
                    newMap[x, z] = (wallCount > 4) ? (byte)1 : (byte)0;
                }
            }
            map = newMap; // Haritayý güncelle
        }

        // 3) Oluþan haritada duvar olan hücrelerde küp oluþtur
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
                if (map[x, z] == 1)
                {
                    Vector3 pos = new Vector3(x * scale, 0, z * scale);
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.position = pos;
                    wall.transform.localScale = new Vector3(scale, scale, scale);
                }
    }
}