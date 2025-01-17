﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    //scenes
    //public string Onboarding;
    //public string Office360;

    //managers
    public UIManagerDockBar uiManagerDockBar;

    //bar
    public Button CalendarButton;

    //time var
    [Range(0f, 10f)]
    public float SceneFadeingSpeed = 0.2f;

    //BGCanvas
    public GameObject HomeBG;
    private CanvasGroup HomeBGAlpha;
    public GameObject MonocromeBG;
    private CanvasGroup MonocromeBGAlpha;
    public GameObject SignInUp;
    private CanvasGroup SignInUpAlpha;
    public GameObject ScrollViewChat;
    private CanvasGroup ScrollViewChatAlpha;
    public GameObject ShadeFadeOut;
    private CanvasGroup ShadeFadeOutAlpha;
    public GameObject ScrollView;
    private CanvasGroup ScrollViewAlpha;

    public GameObject CalendarContent;
    private CanvasGroup CalendarContentAlpha;
    public GameObject ManagerContent;
    private CanvasGroup ManagerContentAlpha;
    public GameObject TeamContent;
    private CanvasGroup TeamContentAlpha;
    public GameObject ProfileContent;
    private CanvasGroup ProfileContentAlpha;

    public GameObject ReminderMessages;

    //time var
    [Range(0f, 10f)]
    public float AnimSpeed = 0.6f;

    public GameObject LoadingCircle;

    public void Awake()
    {
        if (ReminderMessages != null)
            ReminderMessages.SetActive(true);

        HomeBGAlpha = HomeBG.GetComponent<CanvasGroup>();
        MonocromeBGAlpha = MonocromeBG.GetComponent<CanvasGroup>();
        SignInUpAlpha = SignInUp.GetComponent<CanvasGroup>();
        ScrollViewChatAlpha = ScrollViewChat.GetComponent<CanvasGroup>();
        ShadeFadeOutAlpha = ShadeFadeOut.GetComponent<CanvasGroup>();

        ScrollViewAlpha = ScrollView.GetComponent<CanvasGroup>();

        CalendarContentAlpha = CalendarContent.GetComponent<CanvasGroup>();
        ManagerContentAlpha = ManagerContent.GetComponent<CanvasGroup>();
        TeamContentAlpha = TeamContent.GetComponent<CanvasGroup>();
        ProfileContentAlpha = ProfileContent.GetComponent<CanvasGroup>();

       // CalendarSceneBool = true;
    }   

    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Onboarding")
            CalendarButton.Select();
        //else if (sceneName == "Office360")
        //    CalendarButton.Select();
    }

    public void SignInUpCanvas()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(LoadingCircle.transform.DOScale(new Vector3(30, 30, 30), AnimSpeed).SetEase(Ease.InQuad))
            .Join(DOTween.To(() => SignInUpAlpha.alpha, x => SignInUpAlpha.alpha = x, 0, SceneFadeingSpeed).SetEase(Ease.InQuad))
            .AppendInterval(0.5f)
            .Append(DOTween.To(() => ShadeFadeOutAlpha.alpha, x => ShadeFadeOutAlpha.alpha = x, 1, SceneFadeingSpeed));

        SignInUp.SetActive(false);
        Invoke("HomeBGOn", (AnimSpeed+ SceneFadeingSpeed));
    }

    public void RestartSignInUpCanvas()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(DOTween.To(() => ScrollViewChatAlpha.alpha, x => ScrollViewChatAlpha.alpha = x, 0, SceneFadeingSpeed).SetEase(Ease.InQuad))
            .Append(DOTween.To(() => ScrollViewAlpha.alpha, x => ScrollViewAlpha.alpha = x, 0, SceneFadeingSpeed).SetEase(Ease.InQuad));

        //SignInUp.SetActive(true);
        Invoke("HomeBGOff", (AnimSpeed + SceneFadeingSpeed));
    }

    void HomeBGOn()
    {
        HomeBG.SetActive(false);

        DOTween.To(() => ScrollViewChatAlpha.alpha, x => ScrollViewChatAlpha.alpha = x, 1, SceneFadeingSpeed).SetEase(Ease.InQuad);
        DOTween.To(() => ScrollViewAlpha.alpha, x => ScrollViewAlpha.alpha = x, 1, SceneFadeingSpeed).SetEase(Ease.InQuad);
    }

    void HomeBGOff()
    {
        HomeBG.SetActive(true);
        SignInUp.SetActive(true);

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(DOTween.To(() => ShadeFadeOutAlpha.alpha, x => ShadeFadeOutAlpha.alpha = x, 0, 0))
           .Append(LoadingCircle.transform.DOScale(new Vector3(0, 0, 0), AnimSpeed).SetEase(Ease.InQuad))
           .Append(DOTween.To(() => SignInUpAlpha.alpha, x => SignInUpAlpha.alpha = x, 1, SceneFadeingSpeed).SetEase(Ease.InQuad));
    }

    public void BotOnOff()
    {
        SignInUp.SetActive(false);
        ScrollViewChat.SetActive(false);
    }

    public void NotSphereScene()
    {
            DOTween.To(() => MonocromeBGAlpha.alpha, x => MonocromeBGAlpha.alpha = x, 1, SceneFadeingSpeed).SetEase(Ease.InQuad);
            StartCoroutine(FadeInNotSphereScene());
    }

    IEnumerator FadeInNotSphereScene()
    {
        yield return new WaitForSeconds(SceneFadeingSpeed);

        CalendarContentAlpha.alpha = 1;
        ManagerContentAlpha.alpha = 1;
        TeamContentAlpha.alpha = 1;
        ProfileContentAlpha.alpha = 1;
    }

    public void SphereScene()
    {
            HomeBGAlpha.alpha = 0;

            DOTween.To(() => MonocromeBGAlpha.alpha, x => MonocromeBGAlpha.alpha = x, 0, SceneFadeingSpeed).SetEase(Ease.InQuad);

            SignInUpAlpha.alpha = 0;
            CalendarContentAlpha.alpha = 0;
            ManagerContentAlpha.alpha = 0;
            TeamContentAlpha.alpha = 0;
            ProfileContentAlpha.alpha = 0;
    }

}
