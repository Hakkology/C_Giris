using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAIBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform hedef;
    // Start is called before the first frame update
    void Start()
    {
        //_agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hedef !=null)
        {
            agent.SetDestination(hedef.position);
        }
    }
}
