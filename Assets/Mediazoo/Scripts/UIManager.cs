using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    //scenes
    //public string Onboarding;
    //public string Office360;

    //bar
    public Button CalendarButton;
    public Button Button360;

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
        //SceneManager.LoadScene(Onboarding, LoadSceneMode.Single);
        HomeBGAlpha.alpha = 1;
        MonocromeBGAlpha.alpha = 1;
        SignInUpAlpha.alpha = 1;
        ScrollViewAlpha.alpha = 1;
    }

    public void SphereScene()
    {
        //SceneManager.LoadScene(Office360, LoadSceneMode.Single);
        HomeBGAlpha.alpha = 0;
        MonocromeBGAlpha.alpha = 0;
        SignInUpAlpha.alpha = 0;
        ScrollViewAlpha.alpha = 0;
    }
}
