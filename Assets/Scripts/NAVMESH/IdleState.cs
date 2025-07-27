using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IdleState : IState
{
    public void EnterState(HardAIBehaviour aIBehaviour)
    {

    }

    public void ExitState(HardAIBehaviour aIBehaviour)
    {

    }

    public void UpdateState(HardAIBehaviour aIBehaviour)
    {
        if (aIBehaviour._oyuncuMesafesi < aIBehaviour.farketmeYaricapi)
        {
            aIBehaviour.SwitchState(new ChaseState());
        }
    }
}
