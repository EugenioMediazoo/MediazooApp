using System.Collections;
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
    public GameObject SignInChatContent;
    public GameObject CalendarContent;
    public GameObject ManagerConent;
    public GameObject TeamConent;
    public GameObject ProfileContent;
    public Image UserIconImg;

    //string
    //[HideInInspector]
    public string CanvasRecord;
    public bool pressed = true;

    //scrolling
    public GameObject ScrollView;
    private float ScrollWait;

    //dockbar
    public GameObject DockBar;

    public void Awake()
    {
        CalendarContent.transform.DOMoveX(OffScreenRight.transform.position.x, 0);

        TeamConent.transform.DOMoveX(OffScreenRight.transform.position.x, 0);
        ProfileContent.transform.DOMoveX(OffScreenRight.transform.position.x, 0);
        ManagerConent.transform.DOMoveX(OffScreenRight.transform.position.x, 0);

        ScrollWait = ScrollView.GetComponent<AutoScroll>().ScrollSpeed;
    }

    //public void SignInCanvas()
    //{
    //    Sequence mySequence = DOTween.Sequence();
    //    mySequence.PrependInterval(ScrollWait)
    //      .Append(SignInChatContent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
    //      .Join(CalendarContent.transform.DOMoveX(ScreenCenter.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
    //      .Join(ManagerConent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
    //      .Join(TeamConent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
    //      .Join(ProfileContent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));

    //    CanvasRecord = "CalendarCanvas";
    //}

    public void ShowDockBar()
    {
        DockBar.transform.DOMoveY(0, AnimSpeed).SetEase(Ease.InOutCubic);
    }

    public void CalendarCanvas()
    {
        pressed = true;
        CanvasRecord = "CalendarCanvas";

        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(ScrollWait)
          .Append(CalendarContent.transform.DOMoveX(ScreenCenter.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(ManagerConent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(TeamConent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(ProfileContent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
    }

    public void ManagerCanvas()
    {
        pressed = true;
        CanvasRecord = "ManagerCanvas";

        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(ScrollWait)
          .Append(CalendarContent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(ManagerConent.transform.DOMoveX(OnScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(TeamConent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(ProfileContent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
    }

    public void TeamCanvas()
    {
        pressed = true;
        CanvasRecord = "TeamCanvas";

        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(ScrollWait)
          .Append(CalendarContent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(ManagerConent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(TeamConent.transform.DOMoveX(OnScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
          .Join(ProfileContent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
    }

    public void ProfileCanvas()
    {
        if (CanvasRecord == null)
        {
            UserIconImg.transform.DOLocalRotate(new Vector3(0, 0, 2160), AnimSpeed, RotateMode.FastBeyond360).SetEase(Ease.InOutCubic);
        }
        else
        {

            if (CanvasRecord.Contains("CalendarCanvas") is true && !pressed)
            {
                pressed = !pressed;

                Sequence mySequence = DOTween.Sequence();
                mySequence.PrependInterval(ScrollWait)
                  .Append(CalendarContent.transform.DOMoveX(ScreenCenter.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
                  .Join(ProfileContent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
            }
            else if (CanvasRecord.Contains("CalendarCanvas") is true && pressed)
            {
                pressed = !pressed;

                Sequence mySequence = DOTween.Sequence();
                mySequence.PrependInterval(ScrollWait)
                  .Append(CalendarContent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
                  .Join(ProfileContent.transform.DOMoveX(OnScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
            }

            if (CanvasRecord.Contains("ManagerCanvas") is true && !pressed)
            {
                pressed = !pressed;

                Sequence mySequence = DOTween.Sequence();
                mySequence.PrependInterval(ScrollWait)
                  .Append(ManagerConent.transform.DOMoveX(OnScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
                  .Join(ProfileContent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
            }
            else if (CanvasRecord.Contains("ManagerCanvas") is true && pressed)
            {
                pressed = !pressed;

                Sequence mySequence = DOTween.Sequence();
                mySequence.PrependInterval(ScrollWait)
                    .Append(ManagerConent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
                    .Join(ProfileContent.transform.DOMoveX(OnScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
            }


            if (CanvasRecord.Contains("TeamCanvas") is true && !pressed)
            {
                pressed = !pressed;

                Sequence mySequence = DOTween.Sequence();
                mySequence.PrependInterval(ScrollWait)
                    .Append(TeamConent.transform.DOMoveX(OnScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
                    .Join(ProfileContent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
            }
            else if (CanvasRecord.Contains("TeamCanvas") is true && pressed)
            {
                pressed = !pressed;

                Sequence mySequence = DOTween.Sequence();
                mySequence.PrependInterval(ScrollWait)
                    .Append(TeamConent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
                    .Join(ProfileContent.transform.DOMoveX(OnScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
            }

            if (CanvasRecord.Contains("SphereCanvas") is true && !pressed)
            {
                pressed = !pressed;
                Debug.Log("off" + pressed);

                Sequence mySequence = DOTween.Sequence();
                mySequence.PrependInterval(ScrollWait)
                    .Append(ProfileContent.transform.DOMoveX(OffScreenRight.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
                    .Join(CalendarContent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
                    .Join(ManagerConent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
                    .Join(TeamConent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
            }
            else if (CanvasRecord.Contains("SphereCanvas") is true && pressed)
            {
                pressed = !pressed;

                Debug.Log("on" + pressed);

                Sequence mySequence = DOTween.Sequence();
                mySequence.PrependInterval(ScrollWait)
                    .Append(ProfileContent.transform.DOMoveX(OnScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
                    .Join(CalendarContent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
                    .Join(ManagerConent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic))
                    .Join(TeamConent.transform.DOMoveX(OffScreenLeft.transform.position.x, AnimSpeed).SetEase(Ease.InOutCubic));
            }
        }

    }

}
