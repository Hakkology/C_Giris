using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    public Transform Oyuncu;
    public float farketmeYaricapi = 10f;
    public float saldiriYaricapi = 2f;

    private NavMeshAgent _agent;
    private float _oyuncuMesafesi;

    enum State
    {
        Idle,
        Chase,
        Attack
    }

    private State mevcutState = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _oyuncuMesafesi = Vector3.Distance(Oyuncu.transform.position, transform.position);

        switch (mevcutState)
        {
            case State.Idle:
                IdleUpdate();
                break;
            case State.Chase:
                ChaseUpdate();
                break;
            case State.Attack:
                AttackUpdate();
                break;

        }
    }

    private void AttackUpdate()
    {
        _agent.isStopped = true;

        if (_oyuncuMesafesi > 2)
        {
            _agent.isStopped = false;
            mevcutState = State.Chase;
        }
    }

    private void ChaseUpdate()
    {
        _agent.isStopped = false;
        if (_oyuncuMesafesi < saldiriYaricapi)
        {
            mevcutState = State.Attack;
        }

        if (_oyuncuMesafesi > farketmeYaricapi)
        {
            mevcutState = State.Idle;
        }

        _agent.SetDestination(Oyuncu.transform.position);
    }

    private void IdleUpdate()
    {
        //if (Physics.CheckSphere(transform.position, farketmeYaricapi, LayerMask.GetMask("Player")))
        //{
        //    mevcutState = State.Chase;
        //}
        //if (!Physics.CheckSphere(transform.position, farketmeYaricapi, LayerMask.GetMask("Player")) && _oyuncuMesafesi <10)
        //{

        //}
        if (_oyuncuMesafesi < 10)
        {
            mevcutState = State.Chase;
        }
    }
}
