using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GUIMenuManager1 : MonoBehaviour
{
    [SerializeField] protected CanvasGroup canvasGroup;
    protected Tween currentTween;

    [SerializeField] protected float transitionDuration = 0.25f;
    [SerializeField] protected Ease transitionEase = Ease.OutCubic;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OpenPanel()
    {
        currentTween?.Kill();
        //IsOpen = true;
        gameObject.SetActive(true);
        currentTween = canvasGroup.DOFade(1f, transitionDuration)
            .SetEase(transitionEase)
            .SetUpdate(true)
            .OnStart(() =>
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            });
    }

    public virtual void ClosePanel()
    {
        currentTween?.Kill();
        //IsOpen = false;
        currentTween = canvasGroup.DOFade(0f, transitionDuration)
            .SetEase(transitionEase)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                gameObject.SetActive(false);
            });
    }
}
