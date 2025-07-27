using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartEvent : MonoBehaviour
{
    //UnityEvent unityEvent;
    Action onStart;

    public Button button;


    private void Start()
    {
        button.onClick.AddListener(CalisanEvent);
    }

    void EventTetikleyici()
    {
        onStart.Invoke();
    }

    public void CalisanEvent()
    {
        Debug.Log("BASLADÝ OYUN");
    }

    private void OnEnable()
    {
        onStart += CalisanEvent;
    }

    private void OnDisable()
    {
        onStart -= CalisanEvent;
    }


}
