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

        transform.position -= new Vector3(0, .01f, 0);
        //Debug.Log("Mevcut konumu: " + transform.position);

        if (transform.position.y < -5)
        {
            transform.position = new Vector3(0, 5, 0);
            sayac++;
            Debug.Log("küp ýþýnlandý. Konumu: " + transform.position + "Deneme sayýsý: " + sayac);
        }

        //transform.Translate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += new Vector3(0, 3, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(1, 0 , 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(-1, 0, 0);
        }

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    transform.Rotate(new Vector3(0, 45, 0));
        //}

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    transform.Rotate (new Vector3(0, -45, 0));
        //}

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 5 * Time.deltaTime );
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 5);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 1, 0);
        }

    }
}
