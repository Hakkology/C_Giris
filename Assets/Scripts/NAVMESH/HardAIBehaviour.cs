using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class HardAIBehaviour : MonoBehaviour
{
    public Transform Oyuncu;
    public float farketmeYaricapi = 10f;
    public float saldiriYaricapi = 2f;

    public NavMeshAgent _agent { get; private set; }
    public float _oyuncuMesafesi { get; private set; }

    private IState _mevcutState;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _oyuncuMesafesi = Vector3.Distance(Oyuncu.transform.position, transform.position);

        _mevcutState.UpdateState(this);
    }

    public void SwitchState(IState newState)
    {
        _mevcutState?.ExitState(this);
        _mevcutState = newState;
        _mevcutState.EnterState(this);
    }
}
