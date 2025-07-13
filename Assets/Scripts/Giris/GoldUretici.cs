using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldUretici : MonoBehaviour
{
    public GameObject altin;
    private float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-10, 10);
        float z = Random.Range(-10, 10);

        Instantiate(altin, new Vector3(x, 0.5f, z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown >= 5)
        {
            cooldown = 0;
            float x = Random.Range(-10, 10);
            float z = Random.Range(-10, 10);

            Instantiate(altin, new Vector3(x, 0.5f, z), Quaternion.identity);
        }
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (LayerMask.LayerToName(other.gameObject.layer) == "Enemy")
    //    {
    //        Debug.Log("Enemy çarpýþmasý: " + other.name);
    //    }

    //    if (LayerMask.LayerToName(other.gameObject.layer) == "Enemy" ||
    //LayerMask.LayerToName(other.gameObject.layer) == "Engel")
    //    {
    //        // ...
    //    }
    //}
}
