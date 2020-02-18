﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManagerDockBar : MonoBehaviour
{
    //time var
    [Range(0f, 10f)]
    public float AnimSpeed;

    //pos var
    public GameObject OffScreenLeft;
    public GameObject OnScreenLeft;
    public GameObject ScreenCenter;
    public GameObject OnScreenRight;
    public GameObject OffScreenRight;

    //screens
    public GameObject CalendarContent;
    public GameObject TeamConent;

    //scrolling
    public GameObject ScrollView;
    private float ScrollWait;

    public void Awake()
    {
        TeamConent.transform.DOMoveX(OffScreenRight.transform.position.x, 0);
        ScrollWait = ScrollView.GetComponent<AutoScroll>().ScrollSpeed;
    }

    public void CalendarCanvas()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(ScrollWait)
          .Append(CalendarContent.transform.DOMoveX(ScreenCenter.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(TeamConent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
    }    

    public void TeamCanvas()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(ScrollWait)
          .Append(CalendarContent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(TeamConent.transform.DOMoveX(OnScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
        
    }

}
