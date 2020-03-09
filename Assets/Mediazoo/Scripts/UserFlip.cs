using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UserFlip : MonoBehaviour
{
    //time var
    [Range(0f, 10f)]
    public float AnimSpeed;

    //user1
    public Image UserFontInfo;
    private CanvasGroup UserFontInfoCG;
    public Image UserBackInfo;
    private CanvasGroup UserBackInfoCG;
    private void Awake()
    {
        //user1
        UserFontInfoCG = UserFontInfo.GetComponent<CanvasGroup>();
        UserBackInfoCG = UserBackInfo.GetComponent<CanvasGroup>();

        UserBackInfoCG.alpha = 0;

        UserFontInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), 0);
        UserBackInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0);
    }


    public void FlipUserFront()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence
          .Append(UserBackInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0))
          .Append(UserFontInfo.transform.DOLocalRotate(new Vector3(0, -90, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.InCubic))
          .Append(DOTween.To(() => UserFontInfoCG.alpha, x => UserFontInfoCG.alpha = x, 0, 0))
          .Join(DOTween.To(() => UserBackInfoCG.alpha, x => UserBackInfoCG.alpha = x, 1, 0))
          .Append(UserBackInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.OutCubic));
    }

    public void FlipUserBack()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence
          .Append(UserFontInfo.transform.DOLocalRotate(new Vector3(0, 90, 0), 0))
          .Append(UserBackInfo.transform.DOLocalRotate(new Vector3(0, -90, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.InCubic))
          .Append(DOTween.To(() => UserFontInfoCG.alpha, x => UserFontInfoCG.alpha = x, 1, 0))
          .Join(DOTween.To(() => UserBackInfoCG.alpha, x => UserBackInfoCG.alpha = x, 0, 0))
          .Append(UserFontInfo.transform.DOLocalRotate(new Vector3(0, 0, 0), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.OutCubic));
    }
}
