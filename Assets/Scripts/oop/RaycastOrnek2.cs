using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastOrnek2 : MonoBehaviour
{
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log(hit.collider.gameObject.name + " ile çarpýþtý!");
        }
    }
}
