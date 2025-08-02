using UnityEngine;
// Basit procedural cave (ma�ara) algoritmas�.
// Cellular automata ile ma�ara benzeri bir yap� �retir.
public class MagaraTerrain : MonoBehaviour
{
    public int width = 40;          // Haritan�n geni�li�i (x)
    public int depth = 40;          // Haritan�n derinli�i (z)
    public int scale = 2;           // Her k�p�n boyutu
    public int fillPercent = 45;    // Ba�lang��ta % ka� h�cre duvar olacak?
    public int smoothSteps = 5;     // Ka� kere p�r�zs�zle�tirilecek (iteration)?

    byte[,] map;                    // Ma�ara haritas� (0 = zemin, 1 = duvar)

    void Start()
    {
        map = new byte[width, depth];

        // 1) Haritay� rastgele doldur (duvar ve zemin)
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
                // fillPercent'e g�re rastgele 1 (duvar) veya 0 (zemin) ata
                map[x, z] = (byte)(Random.Range(0, 100) < fillPercent ? 1 : 0);

        // 2) Cellular Automata ile ma�aray� p�r�zs�zle�tir
        for (int step = 0; step < smoothSteps; step++)
        {
            byte[,] newMap = new byte[width, depth];

            for (int z = 0; z < depth; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    int wallCount = 0; // Kom�u h�crelerde ka� duvar var?

                    // 3x3 kom�uluk kontrol� (kendisi dahil)
                    for (int dz = -1; dz <= 1; dz++)
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            int nx = x + dx, nz = z + dz;
                            // S�n�r d��� ise, duvar gibi say (kapanma sa�lan�r)
                            if (nx < 0 || nz < 0 || nx >= width || nz >= depth)
                                wallCount++;
                            else if (map[nx, nz] == 1)
                                wallCount++;
                        }
                    // 5 ve �zeri kom�uda duvar varsa, buras� duvar olsun
                    newMap[x, z] = (wallCount > 4) ? (byte)1 : (byte)0;
                }
            }
            map = newMap; // Haritay� g�ncelle
        }

        // 3) Olu�an haritada duvar olan h�crelerde k�p olu�tur
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