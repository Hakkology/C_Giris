using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityMetod : MonoBehaviour
{
    public PlayerBehaviour playerBehaviour; // PlayerBehaviour scriptine referans
    private void Awake()
    {
        playerBehaviour = gameObject. GetComponent<PlayerBehaviour>();
        // Awake metodu, nesne olu�turuldu�unda ilk olarak �a�r�l�r.
        Debug.Log("Awake metodu �a�r�ld�.");

    }
    // Start is called before the first frame update
    private void Start()
    {
        // Start metodu, nesne sahneye eklendi�inde bir kez �a�r�l�r.
        Debug.Log("Start metodu �a�r�ld�.");
    }

    // Update is called once per frame
    private void Update()
    {
        // Update metodu, her frame'de �a�r�l�r.
        Debug.Log("Update metodu �a�r�ld�.");
    }

    private void FixedUpdate()
    {
        // FixedUpdate metodu, fizik hesaplamalar� i�in kullan�l�r ve sabit zaman aral�klar�nda �a�r�l�r.
        Debug.Log("FixedUpdate metodu �a�r�ld�.");
    }

    private void LateUpdate()
    {
        // LateUpdate metodu, Update metodundan sonra �a�r�l�r.
        Debug.Log("LateUpdate metodu �a�r�ld�.");
    }

    private void OnEnable()
    {
        // OnEnable metodu, nesne etkinle�tirildi�inde �a�r�l�r.
        Debug.Log("OnEnable metodu �a�r�ld�.");
    }

    private void OnDisable()
    {
        // OnDisable metodu, nesne devre d��� b�rak�ld���nda �a�r�l�r.
        Debug.Log("OnDisable metodu �a�r�ld�.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // OnCollisionEnter metodu, nesne bir ba�ka nesneyle �arp��t���nda �a�r�l�r.
        Debug.Log("�arp��ma ger�ekle�ti: " + collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        // OnCollisionStay metodu, nesne bir ba�ka nesneyle �arp��ma durumunda kald���nda �a�r�l�r.
        Debug.Log("�arp��ma devam ediyor: " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {

        // OnCollisionExit metodu, nesne bir ba�ka nesneden ayr�ld���nda �a�r�l�r.
        Debug.Log("�arp��ma sona erdi: " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        // OnTriggerEnter metodu, nesne bir tetikleyiciye girdi�inde �a�r�l�r.
        Debug.Log("Tetikleyiciye girildi: " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        // OnTriggerStay metodu, nesne bir tetikleyicide kald���nda �a�r�l�r.
        Debug.Log("Tetikleyicide kal�n�yor: " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        // OnTriggerExit metodu, nesne bir tetikleyiciden ��kt���nda �a�r�l�r.
        Debug.Log("Tetikleyiciden ��k�ld�: " + other.gameObject.name);
    }
}
