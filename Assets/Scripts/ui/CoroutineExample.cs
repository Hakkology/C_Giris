using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    WaitForSeconds beklemeSuresi = new WaitForSeconds(2);
    void Start()
    {
        StartCoroutine(MyCoroutine());

        Invoke(nameof(Bekleme), 2);
    }

    IEnumerator MyCoroutine()
    {
        Debug.Log("Coroutine ba�lad�.");

        // Belirli bir s�re bekleyerek i�lemi duraklat�r
        yield return beklemeSuresi;

        Debug.Log("2 saniye bekledikten sonra devam etti.");
    }

    void Bekleme()
    {
        Debug.Log("2 saniye bekledikten sonra devam etti.");
    }
}