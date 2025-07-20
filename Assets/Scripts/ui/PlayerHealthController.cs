using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int maxCan = 100;
    private int mevcutCan;


    void Start()
    {
        mevcutCan = maxCan;
        UIManager.Instance.hudManager.UpdateCanMetin(mevcutCan.ToString());
    }

    public void HasarAl(int hasar)
    {
        mevcutCan -= hasar;
        UIManager.Instance.hudManager.UpdateCanMetin(mevcutCan.ToString());

        if (mevcutCan <= 0)
        {
            Geber();
        }
    }

    private void Geber()
    {
        UIManager.Instance.guiManager.ShowGameOverScreen();
        //UIManager.Instance.can = 0;
        Destroy(gameObject);
    }
}
