using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIManagerSignIn : MonoBehaviour
{
    //managers scripts
    public UIManager uiManager; /*this is both used for time and methods*/
    public UIManagerTItle uiManagerTItle;
    public UIManagerDockBar uiManagerDockBar;

    //time var
    [Range(0f, 10f)]
    public float AnimSpeed = 0.6f;

    //time var
    [Range(0f, 10f)]
    public float AnimSpeedDots = 0.2f;

    //Sign in main button
    public GameObject SignIn;

    //gameobjects automated chats
    public GameObject[] chats;
    private CanvasGroup chatCG;
    private int o = 0;

    //typing dots
    public GameObject Typing;
    public CanvasGroup[] dotsCG;

    //gameobjets possible answers
    public GameObject AnswerOne;
    private CanvasGroup AnswerOneCG;
    public GameObject AnswerTwo;
    private CanvasGroup AnswerTwoCG;

    //buttons options
    public GameObject OptionContainer;
    private CanvasGroup OptionContainerCG;
    public GameObject OptionOneObj;
    private CanvasGroup OptionOneCG;
    public GameObject OptionTwoObj;
    private CanvasGroup OptionTwoCG;

    //Instrctions
    public GameObject DockBarButton;

    //restartmethod
    public GameObject[] SignInBubbles;
    public int playAgain=0;

    void Awake()
    {
        if (SignInBubbles == null)
            SignInBubbles = GameObject.FindGameObjectsWithTag("SignInBubbles");

        foreach (GameObject SignInBubble in SignInBubbles)
        {
            SignInBubble.SetActive(false);
            SignInBubble.GetComponent<CanvasGroup>().alpha = 0;
        }

        playAgain++;
    }

    public void Replay()
    {
        if (SignInBubbles == null)
            SignInBubbles = GameObject.FindGameObjectsWithTag("SignInBubbles");
        else if(playAgain>2)
        {
            SignInBubbles = GameObject.FindGameObjectsWithTag("SignInBubbles");

            foreach (GameObject SignInBubble in SignInBubbles)
            {
                SignInBubble.SetActive(false);
                SignInBubble.GetComponent<CanvasGroup>().alpha = 0;
            }
        }

        playAgain++;
    }

    public void Ready()
    {
        Invoke("starter", (uiManager.SceneFadeingSpeed + (uiManager.AnimSpeed * 4)));
        Invoke("typing", (uiManager.SceneFadeingSpeed + (uiManager.AnimSpeed * 4)));
    }

    void starter()
    {
        SignIn.SetActive(true);
        
        StartCoroutine(MyFunctions());
    }

    IEnumerator MyFunctions()
    {
        WaitForSeconds wait = new WaitForSeconds(AnimSpeed * 2);

        for (o = 0; o < chats.Length; o++)
        {
            yield return wait;

            chats[o].SetActive(true);

            chatCG = chats[o].GetComponent<CanvasGroup>();
            DOTween.To(() => chatCG.alpha, x => chatCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuart);
        }

        yield return wait;

        Typing.SetActive(false);

        OptionContainer.SetActive(true);
        if (playAgain > 2)
        {
            OptionOneObj.SetActive(true);
            OptionOneCG = OptionOneObj.GetComponent<CanvasGroup>();
            OptionOneCG.alpha = 1;

            OptionTwoObj.SetActive(true);
            OptionTwoCG = OptionTwoObj.GetComponent<CanvasGroup>();
            OptionTwoCG.alpha = 1;
        }

        OptionContainerCG = OptionContainer.GetComponent<CanvasGroup>();
        DOTween.To(() => OptionContainerCG.alpha, x => OptionContainerCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuart);
    }

    public void typing()
    {
        Typing.SetActive(true);

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(DOTween.To(() => dotsCG[0].alpha, x => dotsCG[0].alpha = x, 0.8f, AnimSpeedDots).SetEase(Ease.InOutQuint).SetLoops(0, LoopType.Yoyo))
            .Append(DOTween.To(() => dotsCG[1].alpha, x => dotsCG[1].alpha = x, 0.8f, AnimSpeedDots).SetEase(Ease.InOutQuint).SetLoops(0, LoopType.Yoyo))
            .Append(DOTween.To(() => dotsCG[2].alpha, x => dotsCG[2].alpha = x, 0.8f, AnimSpeedDots).SetEase(Ease.InOutQuint).SetLoops(0, LoopType.Yoyo))
            .SetLoops(-1);
    }

    public void OptionOne()
    {
        AnswerOne.SetActive(true);

        AnswerOneCG = AnswerOne.GetComponent<CanvasGroup>();
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(DOTween.To(() => OptionContainerCG.alpha, x => OptionContainerCG.alpha = x, 0, AnimSpeed/2).SetEase(Ease.InQuart))
            .Append(DOTween.To(() => AnswerOneCG.alpha, x => AnswerOneCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuart));

        StartCoroutine(InvokeManagerMethods());
    }

    //conversation finished
    IEnumerator InvokeManagerMethods()
    {
        yield return new WaitForSeconds(AnimSpeed * 3);

        uiManagerTItle.ZoomindText();
        uiManagerDockBar.CalendarCanvas();
        uiManagerDockBar.ShowDockBar();
        uiManager.BotOnOff();

        DockBarButton.SetActive(true);
    }

    public void OptionTwo()
    {
        AnswerTwo.SetActive(true);

    AnswerTwoCG = AnswerTwo.GetComponent<CanvasGroup>();
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(DOTween.To(() => OptionContainerCG.alpha, x => OptionContainerCG.alpha = x, 0, AnimSpeed/2).SetEase(Ease.InQuart))
            .Append(DOTween.To(() => AnswerTwoCG.alpha, x => AnswerTwoCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuart));

        //go back
        StartCoroutine(RestartManagerMethods());
    }

    IEnumerator RestartManagerMethods()
    {
        yield return new WaitForSeconds(AnimSpeed * 3);
        uiManager.RestartSignInUpCanvas();

        Invoke("Replay", 0);
    }
}
