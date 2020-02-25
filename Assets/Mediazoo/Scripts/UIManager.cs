using System.Collections;
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

    //bar
    public Button CalendarButton;
    private bool CalendarSceneBool;

    //BGCanvas
    public GameObject HomeBG;
    private CanvasGroup HomeBGAlpha;
    public GameObject MonocromeBG;
    private CanvasGroup MonocromeBGAlpha;
    public GameObject SignInUp;
    private CanvasGroup SignInUpAlpha;
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

    public GameObject LoadingCircle;
    
    public void Awake()
    {
        if(ReminderMessages != null)
            ReminderMessages.SetActive(true);

        HomeBGAlpha = HomeBG.GetComponent<CanvasGroup>();
        MonocromeBGAlpha = MonocromeBG.GetComponent<CanvasGroup>();
        SignInUpAlpha = SignInUp.GetComponent<CanvasGroup>();
        ScrollViewAlpha = ScrollView.GetComponent<CanvasGroup>();

        CalendarContentAlpha = CalendarContent.GetComponent<CanvasGroup>();
        ManagerContentAlpha = ManagerContent.GetComponent<CanvasGroup>();
        TeamContentAlpha = TeamContent.GetComponent<CanvasGroup>();
        ProfileContentAlpha = ProfileContent.GetComponent<CanvasGroup>();

        CalendarSceneBool = true;
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

    public void NotSphereScene()
    {
        if (!CalendarSceneBool)
        {
            //SceneManager.LoadScene(Onboarding, LoadSceneMode.Single);
            DOTween.To(() => MonocromeBGAlpha.alpha, x => MonocromeBGAlpha.alpha = x, 1, 0.2f).SetEase(Ease.InQuad);
            StartCoroutine(FadeInNotSphereScene());

            CalendarSceneBool =! CalendarSceneBool;
        }
        else
            return;
    }

    public void SignInUpCanvas()
    {
        //StartCoroutine(FadeInNotSphereScene());

        //MonocromeBGAlpha.alpha = 1;

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(LoadingCircle.transform.DOScale(new Vector3(30, 30, 30), 0.8f).SetEase(Ease.InQuad))
            .Join(DOTween.To(() => SignInUpAlpha.alpha, x => SignInUpAlpha.alpha = x, 0, 0.2f).SetEase(Ease.InQuad));

        SignInUp.SetActive(false);
        Invoke("HomeBGOnOff", 1f);


    }

    void HomeBGOnOff()
    {
        HomeBG.SetActive(false);
        
        DOTween.To(() => ScrollViewAlpha.alpha, x => ScrollViewAlpha.alpha = x, 1, 0.2f).SetEase(Ease.InQuad);
    }

    IEnumerator FadeInNotSphereScene()
    {
        yield return new WaitForSeconds(0.2f);
        //HomeBGAlpha.alpha = 1;
        //SignInUpAlpha.alpha = 1;

        //ScrollViewAlpha.alpha = 1;

        CalendarContentAlpha.alpha = 1;
        ManagerContentAlpha.alpha = 1;
        TeamContentAlpha.alpha = 1;
        ProfileContentAlpha.alpha = 1;
    }

    public void SphereScene()
    {
        if (CalendarSceneBool)
        {
            //SceneManager.LoadScene(Office360, LoadSceneMode.Single);
            HomeBGAlpha.alpha = 0;
            //MonocromeBGAlpha.alpha = 0;

            DOTween.To(() => MonocromeBGAlpha.alpha, x => MonocromeBGAlpha.alpha = x, 0, 0.2f).SetEase(Ease.InQuad);

            SignInUpAlpha.alpha = 0;
            //ScrollViewAlpha.alpha = 0;
            CalendarContentAlpha.alpha = 0;
            ManagerContentAlpha.alpha = 0;
            TeamContentAlpha.alpha = 0;
            ProfileContentAlpha.alpha = 0;

            CalendarSceneBool = !CalendarSceneBool;
        }
        else
            return;
    }

}
