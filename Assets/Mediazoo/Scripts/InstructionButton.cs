using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class InstructionButton : MonoBehaviour
{
    //cards
    public GameObject NextCardPivot;
    private CanvasGroup NextCardPivotCG;
    public GameObject CurrentCardPivot;
    private CanvasGroup CurrentCardPivotCG;

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
            NextCardPivot.transform.DORotate(new Vector3(0, 0, 0), animationSpeed, RotateMode.Fast).SetEase(Ease.InOutBack);
            DOTween.To(() => NextCardPivotCG.alpha, x => NextCardPivotCG.alpha = x, 1, (animationSpeed/2)).SetEase(Ease.InCubic);
        }

        CurrentCardPivot.transform.DORotate(new Vector3(0, 0, 25), animationSpeed, RotateMode.Fast).SetEase(Ease.InOutBack);
        DOTween.To(() => CurrentCardPivotCG.alpha, x => CurrentCardPivotCG.alpha = x, 0, animationSpeed).SetEase(Ease.InOutCubic).SetDelay(0.5f);

        if (Marker != null)
        {
            var MarkerPos = Marker.transform.localPosition.x;
            Marker.transform.DOLocalMoveX(MarkerPos + 80, animationSpeed).SetEase(Ease.InOutBack);
        }
        else
            return;
    }
}
