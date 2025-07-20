using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public HUDManager hudManager;
    public GUIManager guiManager;

    public int can;

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

        hudManager = GetComponentInChildren<HUDManager>();
        guiManager = GetComponentInChildren<GUIManager>();
    }
}
