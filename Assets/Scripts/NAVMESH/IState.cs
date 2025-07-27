using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void EnterState(HardAIBehaviour aIBehaviour);
    void UpdateState(HardAIBehaviour aIBehaviour);
    void ExitState(HardAIBehaviour aIBehaviour);
}
