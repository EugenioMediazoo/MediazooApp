﻿using System.Collections;
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
    public GameObject Welcome;
    public GameObject UserIcon;
    public GameObject Zoomind;
    public GameObject Viewer360;
    public GameObject Manager;
    public GameObject Team;
    public GameObject Profile;

    public GameObject Alfred;
    private CanvasGroup AlfredAlpha;

    //pos
    public GameObject OffScreenTopLeft;
    public GameObject OnScreenTopLeft;

    //scrolling
    public GameObject ScrollView;
    private float ScrollWait;


    void Awake()
    {
        Welcome.transform.DOMoveY(OffScreenTopLeft.transform.position.y, 0);
        UserIcon.transform.DOMoveY(OffScreenTopLeft.transform.position.y, 0);
        Zoomind.transform.DOMoveY(OffScreenTopLeft.transform.position.y, 0);
        Viewer360.transform.DOMoveY(OffScreenTopLeft.transform.position.y, 0);
        Manager.transform.DOMoveY(OffScreenTopLeft.transform.position.y, 0);
        Team.transform.DOMoveY(OffScreenTopLeft.transform.position.y, 0);
        Profile.transform.DOMoveY(OffScreenTopLeft.transform.position.y, 0);
        Alfred.transform.DOMoveY(OffScreenTopLeft.transform.position.y, 0);

        AlfredAlpha = Alfred.GetComponent<CanvasGroup>();

        ScrollWait = ScrollView.GetComponent<AutoScroll>().ScrollSpeed;
    }

    public void WelcomeText()
    {
        Sequence mySecondSequence = DOTween.Sequence();
        mySecondSequence.PrependInterval(1f)
          .Append(Welcome.transform.DOMoveY(OnScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InBack))
          .Join(UserIcon.transform.DOMoveY(OnScreenTopLeft.transform.position.y, AnimSpeed).SetEase(Ease.InBack))
          .Join(Alfred.transform.DOMoveY((OnScreenTopLeft.transform.position.y - 260), AnimSpeed).SetEase(Ease.InBack));
          //.Join(DOTween.To(() => AlfredAlpha.alpha, x => AlfredAlpha.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuad));
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
