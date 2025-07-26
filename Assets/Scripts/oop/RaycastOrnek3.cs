using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RaycastOrnek3 : MonoBehaviour
{
    Ray ray;

    void Start()
    {

        CheckForColliders();
    }

    void CheckForColliders()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, 100f, LayerMask.NameToLayer("Dusman")))
        {
            Debug.Log("Something was hit!");
        }
    }
}
