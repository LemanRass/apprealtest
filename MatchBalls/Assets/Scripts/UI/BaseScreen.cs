using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class BaseScreen : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public event Action onShowing = null;
    public event Action onShowed = null;
    public event Action onHidding = null;
    public event Action onHidded = null;

    public virtual async Task Init()
    {

    }

    public virtual async Task Show()
    {
        onShowing?.Invoke();
        canvasGroup.interactable = true;
        await canvasGroup.DOFade(1.0f, 0.2f).AsyncWaitForCompletion();
        canvasGroup.blocksRaycasts = true;
        onShowed?.Invoke();
    }

    public virtual async Task Hide()
    {
        onHidding?.Invoke();
        canvasGroup.blocksRaycasts = false;
        await canvasGroup.DOFade(0.0f, 0.2f).AsyncWaitForCompletion();
        canvasGroup.interactable = false;
        onHidded?.Invoke();
    }

    public virtual void InstantShow()
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public virtual void InstantHide()
    {
        canvasGroup.alpha = 0.0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
