using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Video;

public class SlideInInstruction : MonoBehaviour
{
    private bool low;
    public GameObject BlurBG;
    private CanvasGroup BlurBGCanvas;

    public GameObject MarkerGroup;
    private CanvasGroup MarkerGroupCanvas;

    //animation
    [Range(0.1f, 5)]
    public float animationSpeed = 1;

    void Awake()
    {
        this.transform.DOLocalMoveY(-15000f, 0);
        low = true;

        BlurBGCanvas = BlurBG.GetComponent<CanvasGroup>();
        BlurBGCanvas.alpha = 0;

        if (MarkerGroup != null)
        {
            MarkerGroupCanvas = MarkerGroup.GetComponent<CanvasGroup>();
            MarkerGroupCanvas.alpha = 0;
        }
        else
            return; 
    }

    //void Start()
    //{
    //    this.transform.DOLocalMoveY(-10000f, 2).SetEase(Ease.InCubic);
    //}

    public void MoveInfoUp()
    {
        if (low)
        {
            this.transform.DOLocalMoveY(-10000f, 1).SetEase(Ease.InCubic);
            low = false;

            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(DOTween.To(() => BlurBGCanvas.alpha, x => BlurBGCanvas.alpha = x, 1, (animationSpeed / 2)).SetEase(Ease.InCubic))
                .Append(DOTween.To(() => MarkerGroupCanvas.alpha, x => MarkerGroupCanvas.alpha = x, 1, (animationSpeed / 2)).SetEase(Ease.InCubic));
        }
    }

    public void MoveChatInfoUp()
    {
        if (low)
        {
            this.transform.DOLocalMoveY(-10000f, 1).SetEase(Ease.InCubic);
            low = false;

            DOTween.To(() => BlurBGCanvas.alpha, x => BlurBGCanvas.alpha = x, 1, (animationSpeed / 2)).SetEase(Ease.InCubic);
        }
    }

    public void DeactivateBlur()
    {
        DOTween.To(() => BlurBGCanvas.alpha, x => BlurBGCanvas.alpha = x, 0, (animationSpeed / 2)).SetEase(Ease.InCubic);
        DOTween.To(() => MarkerGroupCanvas.alpha, x => MarkerGroupCanvas.alpha = x, 0, (animationSpeed / 2)).SetEase(Ease.InCubic);
        StartCoroutine(DeactiveBlurObj());
    }

    IEnumerator DeactiveBlurObj()
    {
        yield return new WaitForSeconds(animationSpeed);
        BlurBG.SetActive(false);
    }



}
