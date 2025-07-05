using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kup : MonoBehaviour
{
    int hiz = 5;
    bool yukari = false;
    int sayac = 0;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        //transform.Translate(new Vector3(0, 5,0));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(3, 4, 0));
        //transform.position = transform.position + new Vector3(3, 4, 0);

        //transform.rotation.y += 1;
        //transform.Rotate(new Vector3(1,0,0));
        transform.Rotate(new Vector3(90 * Time.deltaTime, 0 , 0));

        //if (transform.position.y > 5)
        //{
        //    //transform.position += new Vector3(0, hiz * -1 * Time.deltaTime, 0);
        //    yukari = false;
        //}
        //else if (transform.position.y < -5)
        //{
        //    //transform.position += new Vector3(0, hiz* 1 * Time.deltaTime / 2, 0);
        //    yukari = true;
        //}
        //else if (transform.position.y < 5 && transform.position.y > -5)
        //{


        //}

        //if (transform.position.y > 5)
        //{
        //    yukari = false;
        //}
        //else if (transform.position.y < -5)
        //{
        //    yukari = true;
        //}

        //if (yukari == true)
        //{
        //    transform.position += new Vector3(0, hiz * 1 * Time.deltaTime, 0);
        //}
        //else if (yukari == false)
        //{
        //    transform.position -= new Vector3(0, hiz * 1 * Time.deltaTime / 2, 0);
        //}

        transform.position -= new Vector3(0, .1f, 0);
        //Debug.Log("Mevcut konumu: " + transform.position);

        if (transform.position.y < -5)
        {
            transform.position = new Vector3(0, 5, 0);
            sayac++;
            Debug.Log("küp ýþýnlandý. Konumu: " + transform.position + "Deneme sayýsý: " + sayac);
        }

    }
}
