using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    public int maxAmmo;
    public float atesZamanAraligi;
    public float silahDoldurmaZamanAraligi;

    private int mevcutAmmo;
    private bool silahDoluyor;
    private float sonAtesZamani;

    // Start is called before the first frame update
    void Start()
    {
        mevcutAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (silahDoluyor) return;

        if (Input.GetMouseButtonDown(0) && Time.time >sonAtesZamani + atesZamanAraligi)
        {
            Shoot();
        }

        if (mevcutAmmo == 0 && !silahDoluyor)
        {
            Reload();
        }

    }

    private void Reload()
    {
        silahDoluyor = true;
        Debug.Log("Silah dolduruluyor.");
        Invoke(nameof(ReloadFinish), silahDoldurmaZamanAraligi);
    }

    private void ReloadFinish()
    {
        mevcutAmmo = maxAmmo;
        silahDoluyor = false;
        Debug.Log("Silah ateþe hazýr");
    }

    private void Shoot()
    {
        if (mevcutAmmo > 0)
        {
            mevcutAmmo--;
            sonAtesZamani = Time.time;
            Debug.Log("Kalan mermi: " + mevcutAmmo);
        }
    }
}
