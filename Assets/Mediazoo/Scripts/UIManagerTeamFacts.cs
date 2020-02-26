using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManagerTeamFacts : MonoBehaviour
{
    //time var
    [Range(0f, 10f)]
    public float AnimSpeed;

    //user1
    public Image User1FontInfo;
    private CanvasGroup User1FontInfoCG;
    public Image User1BackInfo;
    private CanvasGroup User1BackInfoCG;

    //user2
    public Image User2FontInfo;
    private CanvasGroup User2FontInfoCG;
    public Image User2BackInfo;
    private CanvasGroup User2BackInfoCG;

    //user3
    public Image User3FontInfo;
    private CanvasGroup User3FontInfoCG;
    public Image User3BackInfo;
    private CanvasGroup User3BackInfoCG;


    private void Awake()
    {
        //user1
        User1FontInfoCG = User1FontInfo.GetComponent<CanvasGroup>();
        User1BackInfoCG = User1BackInfo.GetComponent<CanvasGroup>();

        User1BackInfoCG.alpha = 0;

        User1FontInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), 0);
        User1BackInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0);

        //user2
        User2FontInfoCG = User2FontInfo.GetComponent<CanvasGroup>();
        User2BackInfoCG = User2BackInfo.GetComponent<CanvasGroup>();

        User2BackInfoCG.alpha = 0;

        User2FontInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), 0);
        User2BackInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0);

        //user3
        User3FontInfoCG = User3FontInfo.GetComponent<CanvasGroup>();
        User3BackInfoCG = User3BackInfo.GetComponent<CanvasGroup>();

        User3BackInfoCG.alpha = 0;

        User3FontInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), 0);
        User3BackInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0);
    }


    public void FlipUser1Front()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence
          .Append(User1BackInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0))
          .Append(User1FontInfo.transform.DOLocalRotate(new Vector3(0, -90, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.InCubic))
          .Append(DOTween.To(() => User1FontInfoCG.alpha, x => User1FontInfoCG.alpha = x, 0, 0))
          .Join(DOTween.To(() => User1BackInfoCG.alpha, x => User1BackInfoCG.alpha = x, 1, 0))
          .Append(User1BackInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.OutCubic));
    }

    public void FlipUser1Back()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence
          .Append(User1FontInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0))
          .Append(User1BackInfo.transform.DOLocalRotate(new Vector3(0, -90, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.InCubic))
          .Append(DOTween.To(() => User1FontInfoCG.alpha, x => User1FontInfoCG.alpha = x, 1, 0))
          .Join(DOTween.To(() => User1BackInfoCG.alpha, x => User1BackInfoCG.alpha = x, 0, 0))
          .Append(User1FontInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.OutCubic));
    }

    public void FlipUser2Front()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence
          .Append(User2BackInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0))
          .Append(User2FontInfo.transform.DOLocalRotate(new Vector3(0, -90, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.InCubic))
          .Append(DOTween.To(() => User2FontInfoCG.alpha, x => User2FontInfoCG.alpha = x, 0, 0))
          .Join(DOTween.To(() => User2BackInfoCG.alpha, x => User2BackInfoCG.alpha = x, 1, 0))
          .Append(User2BackInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.OutCubic));
    }

    public void FlipUser2Back()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence
          .Append(User2FontInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0))
          .Append(User2BackInfo.transform.DOLocalRotate(new Vector3(0, -90, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.InCubic))
          .Append(DOTween.To(() => User2FontInfoCG.alpha, x => User2FontInfoCG.alpha = x, 1, 0))
          .Join(DOTween.To(() => User2BackInfoCG.alpha, x => User2BackInfoCG.alpha = x, 0, 0))
          .Append(User2FontInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.OutCubic));
    }

    public void FlipUser3Front()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence
          .Append(User3BackInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0))
          .Append(User3FontInfo.transform.DOLocalRotate(new Vector3(0, -90, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.InCubic))
          .Append(DOTween.To(() => User3FontInfoCG.alpha, x => User3FontInfoCG.alpha = x, 0, 0))
          .Join(DOTween.To(() => User3BackInfoCG.alpha, x => User3BackInfoCG.alpha = x, 1, 0))
          .Append(User3BackInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.OutCubic));
    }

    public void FlipUser3Back()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence
          .Append(User3FontInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0))
          .Append(User3BackInfo.transform.DOLocalRotate(new Vector3(0, -90, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.InCubic))
          .Append(DOTween.To(() => User3FontInfoCG.alpha, x => User3FontInfoCG.alpha = x, 1, 0))
          .Join(DOTween.To(() => User3BackInfoCG.alpha, x => User3BackInfoCG.alpha = x, 0, 0))
          .Append(User3FontInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.OutCubic));
    }

}
