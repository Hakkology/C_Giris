using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TekilDuzen : MonoBehaviour
{
    //public int skor;
    public static TekilDuzen Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
