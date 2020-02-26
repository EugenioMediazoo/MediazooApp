using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManagerTeamFacts : MonoBehaviour
{
    public Image User1FontInfo;
    private CanvasGroup User1FontInfoCG;
    public Image User1BackInfo;
    private CanvasGroup User1BackInfoCG;

    //time var
    [Range(0f, 10f)]
    public float AnimSpeed;

    private void Awake()
    {
        User1FontInfoCG = User1FontInfo.GetComponent<CanvasGroup>();
        User1BackInfoCG = User1BackInfo.GetComponent<CanvasGroup>();

        User1BackInfoCG.alpha = 0;

        User1FontInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), 0);
        User1BackInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0);
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

}
