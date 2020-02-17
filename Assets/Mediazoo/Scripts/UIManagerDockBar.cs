using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
//using UnityEngine.EventSystems;

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


    public void Awake()
    {
        TeamConent.transform.DOMoveX(OffScreenRight.transform.position.x, 0);
    }

    public void CalendarCanvas()
    {
        CalendarContent.transform.DOMoveX(ScreenCenter.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic);
        TeamConent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic);
    }

    public void TeamCanvas()
    {
        CalendarContent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic);
        TeamConent.transform.DOMoveX(OnScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic);
    }

}
