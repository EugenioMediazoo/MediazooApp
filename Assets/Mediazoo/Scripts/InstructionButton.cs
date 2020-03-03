using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.Video;

public class InstructionButton : MonoBehaviour
{
    //cards
    public GameObject NextCardPivot;
    private CanvasGroup NextCardPivotCG;
    //public VideoPlayer NextVideo;
    public GameObject CurrentCardPivot;
    private CanvasGroup CurrentCardPivotCG;
   // public VideoPlayer CurrentVideo;

    public GameObject Marker;

    //animation
    [Range(0.1f, 5)]
    public float animationSpeed = 1;

    private void Awake()
    {
        if (NextCardPivot != null)
            NextCardPivotCG = NextCardPivot.GetComponent<CanvasGroup>();

        CurrentCardPivotCG = CurrentCardPivot.GetComponent<CanvasGroup>();
    }

    public void NextCard()
    {
        if (NextCardPivot != null)
        {
            //NextVideo.Play();
            //NextCardPivot.transform.DORotate(new Vector3(0, 0, 0), animationSpeed, RotateMode.Fast).SetEase(Ease.InOutBack).SetDelay(0.2f);
            //DOTween.To(() => NextCardPivotCG.alpha, x => NextCardPivotCG.alpha = x, 1, (animationSpeed/5)).SetEase(Ease.InCubic);
            
            Sequence mySequenceIn = DOTween.Sequence();
            mySequenceIn.Append(DOTween.To(() => NextCardPivotCG.alpha, x => NextCardPivotCG.alpha = x, 1, (0.2f)).SetEase(Ease.InCubic))
                .Append(NextCardPivot.transform.DORotate(new Vector3(0, 0, 0), animationSpeed, RotateMode.Fast).SetEase(Ease.InOutBack).SetDelay(0.3f));
        }

        //CurrentVideo.Stop();
        Sequence mySequenceOut = DOTween.Sequence();
        mySequenceOut.Append(CurrentCardPivot.transform.DORotate(new Vector3(0, 0, 25), animationSpeed, RotateMode.Fast).SetEase(Ease.InOutBack).SetDelay(0.3f))
            .Append(DOTween.To(() => CurrentCardPivotCG.alpha, x => CurrentCardPivotCG.alpha = x, 0, animationSpeed).SetEase(Ease.InOutCubic).SetDelay(0.3f));

        if (Marker != null)
        {
            var MarkerPos = Marker.transform.localPosition.x;
            Marker.transform.DOLocalMoveX(MarkerPos + 80, animationSpeed).SetEase(Ease.InOutBack).SetDelay(0.3f);
        }
        else
            return;
    }
}
