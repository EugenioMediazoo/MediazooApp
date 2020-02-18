using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
//using UnityEngine.EventSystems;

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

    public GameObject ReminderMessages;
    
    public void Awake()
    {
        if(ReminderMessages != null)
            ReminderMessages.SetActive(true);

        HomeBGAlpha = HomeBG.GetComponent<CanvasGroup>();
        MonocromeBGAlpha = MonocromeBG.GetComponent<CanvasGroup>();
        SignInUpAlpha = SignInUp.GetComponent<CanvasGroup>();
        ScrollViewAlpha = ScrollView.GetComponent<CanvasGroup>();
        
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

    public void CalendarScene()
    {
        if (!CalendarSceneBool)
        {
            //SceneManager.LoadScene(Onboarding, LoadSceneMode.Single);
            DOTween.To(() => MonocromeBGAlpha.alpha, x => MonocromeBGAlpha.alpha = x, 1, 0.2f).SetEase(Ease.InQuad);
            StartCoroutine(FadeInCalendar());

            CalendarSceneBool =! CalendarSceneBool;
        }
        else
            return;
    }

    IEnumerator FadeInCalendar()
    {
        yield return new WaitForSeconds(0.2f);
        HomeBGAlpha.alpha = 1;
        SignInUpAlpha.alpha = 1;
        ScrollViewAlpha.alpha = 1;
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
            ScrollViewAlpha.alpha = 0;

            CalendarSceneBool = !CalendarSceneBool;
        }
        else
            return;
    }
    
}
