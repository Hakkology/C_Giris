using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChaseState : IState
{
    public void EnterState(HardAIBehaviour aIBehaviour)
    {
        aIBehaviour._agent.isStopped = false;
    }

    public void ExitState(HardAIBehaviour aIBehaviour)
    {

    }

    public void UpdateState(HardAIBehaviour aIBehaviour)
    {
        aIBehaviour._agent.SetDestination(aIBehaviour.Oyuncu.position);

        if (aIBehaviour._oyuncuMesafesi < aIBehaviour.saldiriYaricapi)
        {
            aIBehaviour.SwitchState(new AttackState());
        }
        else if (aIBehaviour._oyuncuMesafesi > aIBehaviour.farketmeYaricapi)
        {
            aIBehaviour.SwitchState(new IdleState());
        }
    }
}
