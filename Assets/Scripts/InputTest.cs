using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    public int hiz = 3;
    // Update is called once per frame
    void Update()
    {
        //gameObject
        float xHareketi = Input.GetAxis("Horizontal") * Time.deltaTime * hiz;
        float zHareketi = Input.GetAxis("Vertical") * Time.deltaTime * hiz;

        transform.Translate(xHareketi, 0, zHareketi);
    }
}
