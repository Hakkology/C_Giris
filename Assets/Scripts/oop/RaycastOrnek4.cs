using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class RaycastOrnek4 : MonoBehaviour
{
    Ray ray;
    void Start()
    {
        //RaycastHit[] hits = Physics.RaycastAll(ray, 100f);
        //foreach (RaycastHit hit in hits)
        //{
        //    Debug.Log(hit.collider.gameObject.name + " ile �arp��t�!");
        //}

        //int layerMask = LayerMask.GetMask("Enemy");
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, 100f, layerMask))
        //{
        //    Debug.Log("D��man tespit edildi: " + hit.collider.gameObject.name);
        //}

        //if (Input.GetMouseButtonDown(0))
        //{ 
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, 100f))
        //    {
        //        Debug.Log(hit.collider.gameObject.name + " se�ildi!");
        //    }
        //}

        //Ray ray = new Ray(transform.position, Vector3.down);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, 1f))
        //{
        //    Debug.Log("Karakter zemin �zerinde!");
        //}
        //else
        //{
        //    Debug.Log("Karakter hava durumunda!");
        //}


    }

}
