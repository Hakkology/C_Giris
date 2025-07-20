using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovement : MonoBehaviour
{
    public RectTransform uiPanel; // Hareket ettirilecek UI paneli
    public float moveSpeed = 100f; // Hareket hýzý (piksel/saniye)

    void Start()
    {
        StartCoroutine(MovePanel());
    }

    IEnumerator MovePanel()
    {
        float targetPositionX = Screen.width; // Ekran geniþliði kadar saða doðru hareket edecek
        float currentPositionX = uiPanel.anchoredPosition.x;

        while (currentPositionX < targetPositionX)
        {
            // UI panelini saða doðru hareket ettir
            float newX = Mathf.MoveTowards(uiPanel.anchoredPosition.x, targetPositionX, moveSpeed * Time.deltaTime);
            //uiPanel.anchoredPosition = new Vector2(newX, uiPanel.anchoredPosition.y);

            currentPositionX = newX;

            yield return null; // Bir sonraki kareyi bekle
        }

        // Hareket tamamlandýðýnda paneli devre dýþý býrak
        uiPanel.gameObject.SetActive(false);
    }

    // Open için
    IEnumerator MoveOpenPanel()
    {
        // Baþlangýç pozisyonunu ekranýn dýþ sað tarafýna ayarla
        float startPositionX = Screen.width + uiPanel.rect.width / 2; // Ekranýn dýþýndan baþla
        float targetPositionX = Screen.width / 2; // Ekranýn ortasýna taþý
        uiPanel.anchoredPosition = new Vector2(startPositionX, uiPanel.anchoredPosition.y); // Ýlk pozisyonu ayarla

        // Aktif etmeden önce paneli doðru baþlangýç noktasýna koy
        uiPanel.gameObject.SetActive(true);

        // Paneli ekranýn ortasýna kaydýr
        while (uiPanel.anchoredPosition.x > targetPositionX)
        {
            float newX = Mathf.MoveTowards(uiPanel.anchoredPosition.x, targetPositionX, moveSpeed * Time.deltaTime);
            uiPanel.anchoredPosition = new Vector2(newX, uiPanel.anchoredPosition.y);
            yield return null;
        }
    }
}