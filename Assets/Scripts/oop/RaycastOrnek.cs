using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastOrnek : MonoBehaviour
{
    Ray ray;

    void Start()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        CheckForColliders();
    }

    void CheckForColliders()
    {

        bool carptimi = Physics.Raycast(ray, out RaycastHit hit);

        if (carptimi)
        {
            Debug.Log(hit.collider.gameObject.name + " vuruldu!");
        }
    }
}
