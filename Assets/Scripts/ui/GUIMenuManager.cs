using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class GUIMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    public float animasyonSuresi = 0.3f;
    public Vector3 gizliOlcek = Vector3.zero;
    public Vector3 gorulurOlcek = Vector3.one;

    private Tween calismaktaOlanTween;

    void Start()
    {
        mainMenuPanel.transform.localScale = gizliOlcek;
        settingsPanel.transform.localScale = gizliOlcek;

        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        OpenPanel(mainMenuPanel);
        ClosePanel(settingsPanel);
    }

    public void ShowSettingsMenu()
    {
        OpenPanel(settingsPanel);
        ClosePanel(mainMenuPanel);
    }

    //public void StartGame()
    //{
    //    // Oyun sahnesinin adýný gerçek adýyla deðiþtirin
    //    calismaktaOlanTween.Kill();
    //    SceneManager.LoadSceneAsync("TPSTest");
    //}

    public async Task StartGame()
    {
        // Oyun sahnesinin adýný gerçek adýyla deðiþtirin
        calismaktaOlanTween.Kill();
        SceneManager.LoadSceneAsync("TPSTest");
        //return Task.CompletedTask;
    }

    public void QuitGame()
    {
        calismaktaOlanTween.Kill();
        Application.Quit();
        Debug.Log("Game closed"); // Editor'de çýkýþ iþlemini görmek için log
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        calismaktaOlanTween = panel.transform
            .DOScale(gorulurOlcek, animasyonSuresi)
            .SetEase(Ease.OutBack);
    }

    public void ClosePanel(GameObject panel) 
    {
        calismaktaOlanTween = panel.transform.DOScale(gizliOlcek, animasyonSuresi)
            .SetEase (Ease.OutBack)
            .OnComplete(() => panel.SetActive(false));
    }
}
