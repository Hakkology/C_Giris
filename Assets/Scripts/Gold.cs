using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{

    private int hiz = 45;
    // Start is called before the first frame update
    void Start()
    {
        //float x = Random.Range(-10, 10);
        //float z = Random.Range(-10, 10);

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, hiz * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour oyuncu = gameObject.GetComponent<PlayerBehaviour>();
            oyuncu.SkorArtir(10);

            Destroy(gameObject);
        }
    }

}
