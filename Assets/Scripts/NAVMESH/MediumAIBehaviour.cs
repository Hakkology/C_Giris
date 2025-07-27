using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MediumAIBehaviour : MonoBehaviour
{
    public Transform[] nobetNoktalari;
    private NavMeshAgent _agent;
    private int mevcutNobetNoktaIndeksi;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        BirSonrakiNobetNoktasiniSec();
    }

    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance <0.5f)
        {
            BirSonrakiNobetNoktasiniSec();
        }
    }

    private void BirSonrakiNobetNoktasiniSec()
    {
        if (nobetNoktalari.Length == 0)
        {
            Debug.LogError("nokta yok nokta");
            return;
        }


        mevcutNobetNoktaIndeksi = Random.Range(0, nobetNoktalari.Length);
        _agent.SetDestination(nobetNoktalari[mevcutNobetNoktaIndeksi].position);
    }


}
