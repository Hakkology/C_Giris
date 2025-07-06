using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityMetod : MonoBehaviour
{
    public PlayerBehaviour playerBehaviour; // PlayerBehaviour scriptine referans
    private void Awake()
    {
        playerBehaviour = gameObject. GetComponent<PlayerBehaviour>();
        // Awake metodu, nesne oluþturulduðunda ilk olarak çaðrýlýr.
        Debug.Log("Awake metodu çaðrýldý.");

    }
    // Start is called before the first frame update
    private void Start()
    {
        // Start metodu, nesne sahneye eklendiðinde bir kez çaðrýlýr.
        Debug.Log("Start metodu çaðrýldý.");
    }

    // Update is called once per frame
    private void Update()
    {
        // Update metodu, her frame'de çaðrýlýr.
        Debug.Log("Update metodu çaðrýldý.");
    }

    private void FixedUpdate()
    {
        // FixedUpdate metodu, fizik hesaplamalarý için kullanýlýr ve sabit zaman aralýklarýnda çaðrýlýr.
        Debug.Log("FixedUpdate metodu çaðrýldý.");
    }

    private void LateUpdate()
    {
        // LateUpdate metodu, Update metodundan sonra çaðrýlýr.
        Debug.Log("LateUpdate metodu çaðrýldý.");
    }

    private void OnEnable()
    {
        // OnEnable metodu, nesne etkinleþtirildiðinde çaðrýlýr.
        Debug.Log("OnEnable metodu çaðrýldý.");
    }

    private void OnDisable()
    {
        // OnDisable metodu, nesne devre dýþý býrakýldýðýnda çaðrýlýr.
        Debug.Log("OnDisable metodu çaðrýldý.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // OnCollisionEnter metodu, nesne bir baþka nesneyle çarpýþtýðýnda çaðrýlýr.
        Debug.Log("Çarpýþma gerçekleþti: " + collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        // OnCollisionStay metodu, nesne bir baþka nesneyle çarpýþma durumunda kaldýðýnda çaðrýlýr.
        Debug.Log("Çarpýþma devam ediyor: " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {

        // OnCollisionExit metodu, nesne bir baþka nesneden ayrýldýðýnda çaðrýlýr.
        Debug.Log("Çarpýþma sona erdi: " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        // OnTriggerEnter metodu, nesne bir tetikleyiciye girdiðinde çaðrýlýr.
        Debug.Log("Tetikleyiciye girildi: " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        // OnTriggerStay metodu, nesne bir tetikleyicide kaldýðýnda çaðrýlýr.
        Debug.Log("Tetikleyicide kalýnýyor: " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        // OnTriggerExit metodu, nesne bir tetikleyiciden çýktýðýnda çaðrýlýr.
        Debug.Log("Tetikleyiciden çýkýldý: " + other.gameObject.name);
    }
}
