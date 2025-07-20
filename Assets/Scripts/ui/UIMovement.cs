using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovement : MonoBehaviour
{
    public RectTransform uiPanel; // Hareket ettirilecek UI paneli
    public float moveSpeed = 100f; // Hareket h�z� (piksel/saniye)

    void Start()
    {
        StartCoroutine(MovePanel());
    }

    IEnumerator MovePanel()
    {
        float targetPositionX = Screen.width; // Ekran geni�li�i kadar sa�a do�ru hareket edecek
        float currentPositionX = uiPanel.anchoredPosition.x;

        while (currentPositionX < targetPositionX)
        {
            // UI panelini sa�a do�ru hareket ettir
            float newX = Mathf.MoveTowards(uiPanel.anchoredPosition.x, targetPositionX, moveSpeed * Time.deltaTime);
            //uiPanel.anchoredPosition = new Vector2(newX, uiPanel.anchoredPosition.y);

            currentPositionX = newX;

            yield return null; // Bir sonraki kareyi bekle
        }

        // Hareket tamamland���nda paneli devre d��� b�rak
        uiPanel.gameObject.SetActive(false);
    }

    // Open i�in
    IEnumerator MoveOpenPanel()
    {
        // Ba�lang�� pozisyonunu ekran�n d�� sa� taraf�na ayarla
        float startPositionX = Screen.width + uiPanel.rect.width / 2; // Ekran�n d���ndan ba�la
        float targetPositionX = Screen.width / 2; // Ekran�n ortas�na ta��
        uiPanel.anchoredPosition = new Vector2(startPositionX, uiPanel.anchoredPosition.y); // �lk pozisyonu ayarla

        // Aktif etmeden �nce paneli do�ru ba�lang�� noktas�na koy
        uiPanel.gameObject.SetActive(true);

        // Paneli ekran�n ortas�na kayd�r
        while (uiPanel.anchoredPosition.x > targetPositionX)
        {
            float newX = Mathf.MoveTowards(uiPanel.anchoredPosition.x, targetPositionX, moveSpeed * Time.deltaTime);
            uiPanel.anchoredPosition = new Vector2(newX, uiPanel.anchoredPosition.y);
            yield return null;
        }
    }
}