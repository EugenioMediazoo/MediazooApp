using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManagerTItle : MonoBehaviour
{
    //time var
    [Range(0f, 10f)]
    public float AnimSpeed;

    //var
    public GameObject Zoomind;
    public GameObject Viewer360;
    public GameObject Manager;
    public GameObject Team;
    public GameObject Profile;

    //pos
    public GameObject OffScreenTopLeft;
    public GameObject OnScreenTopLeft;

    //scrolling
    public GameObject ScrollView;
    private float ScrollWait;


    void Awake()
    {
        Viewer360.transform.DOMoveY(OffScreenTopLeft.transform.position.y, 0);
        Manager.transform.DOMoveY(OffScreenTopLeft.transform.position.y, 0);
        Team.transform.DOMoveY(OffScreenTopLeft.transform.position.y, 0);
        Profile.transform.DOMoveY(OffScreenTopLeft.transform.position.y, 0);

        ScrollWait = ScrollView.GetComponent<AutoScroll>().ScrollSpeed;
    }

    public void ZoomindText()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(ScrollWait)
          .Append(Viewer360.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(Manager.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(Team.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(Profile.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InOutCubic));
          

        Sequence mySecondSequence = DOTween.Sequence();
        mySecondSequence.PrependInterval(ScrollWait)
          .Append(Zoomind.transform.DOMoveY(OnScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InBack));
    }

    public void ViewerText()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(ScrollWait)
          .Append(Zoomind.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.OutBack))
          .Join(Manager.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.OutBack))
          .Join(Team.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.OutBack))
          .Join(Profile.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.OutBack));


        Sequence mySecondSequence = DOTween.Sequence();
        mySecondSequence.PrependInterval(ScrollWait)
          .Append(Viewer360.transform.DOMoveY(OnScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InBack));
    }

    public void ManagerText()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(ScrollWait)
          .Append(Zoomind.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.OutBack))
          .Join(Viewer360.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.OutBack))
          .Join(Team.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.OutBack))
          .Join(Profile.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.OutBack));
          
        Sequence mySecondSequence = DOTween.Sequence();
        mySecondSequence.PrependInterval(ScrollWait)
          .Append(Manager.transform.DOMoveY(OnScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InBack));
    }

    public void TeamText()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(ScrollWait)
          .Append(Zoomind.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.OutBack))
          .Join(Viewer360.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.OutBack))
          .Join(Manager.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.OutBack))
          .Join(Profile.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.OutBack));

        Sequence mySecondSequence = DOTween.Sequence();
        mySecondSequence.PrependInterval(ScrollWait)
          .Append(Team.transform.DOMoveY(OnScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InBack));

    }

    public void ProfileText()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(ScrollWait)
          .Append(Zoomind.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(Viewer360.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(Team.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(Manager.transform.DOMoveY(OffScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InOutCubic));

        Sequence mySecondSequence = DOTween.Sequence();
        mySecondSequence.PrependInterval(ScrollWait)
          .Append(Profile.transform.DOMoveY(OnScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InBack));
    }
}
