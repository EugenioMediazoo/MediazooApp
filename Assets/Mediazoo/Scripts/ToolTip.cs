using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ToolTip : MonoBehaviour
{
    //time var
    [Range(0f, 10f)]
    public float FadeSpeed = 0.6f;

    //time var
    [Range(0f, 10f)]
    public float AnimSpeed = 2f;


    public GameObject Card;
    private CanvasGroup CardCG;
    public GameObject HandPivot;
    public float AngleLeft;
    public float AngleRight;

    private void Awake()
    {
        Card.SetActive(false);
        CardCG = Card.GetComponent<CanvasGroup>();
        //Invoke("FadeIn", 1);
    }

    public void FadeIn()
    {
        Card.SetActive(true);
        DOTween.To(() => CardCG.alpha, x => CardCG.alpha = x, 1, FadeSpeed).SetEase(Ease.InCubic).OnComplete(MoveHand);
    }

    public void MoveHand()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(HandPivot.transform.DORotate(new Vector3(0,0, AngleLeft),AnimSpeed).SetEase(Ease.InOutSine))
            .Append(HandPivot.transform.DORotate(new Vector3(0, 0, AngleRight), AnimSpeed).SetEase(Ease.InOutSine))
            .SetLoops(3, LoopType.Yoyo)
            .OnComplete(FadeOut);
    }

    public void FadeOut()
    {
        DOTween.To(() => CardCG.alpha, x => CardCG.alpha = x, 0, FadeSpeed).SetEase(Ease.InCubic).OnComplete(Deactivate);
    }

    public void Deactivate()
    {
        Card.SetActive(false);
    }

}
