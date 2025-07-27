using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackState : IState
{
    public void EnterState(HardAIBehaviour aIBehaviour)
    {
        aIBehaviour._agent.isStopped = true;
    }

    public void ExitState(HardAIBehaviour aIBehaviour)
    {
        aIBehaviour._agent.isStopped = false;
    }

    public void UpdateState(HardAIBehaviour aIBehaviour)
    {
        if (aIBehaviour._oyuncuMesafesi > aIBehaviour.saldiriYaricapi)
        {
            aIBehaviour.SwitchState(new ChaseState());
        }
    }
}
