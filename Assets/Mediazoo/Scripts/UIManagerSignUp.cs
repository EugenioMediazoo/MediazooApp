using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIManagerSignUp: MonoBehaviour
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
    public GameObject SignUp;

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

    //inputfields
    public GameObject InputContainerOne;
    private CanvasGroup InputContainerOneCG;


    public void Ready()
    {
        Invoke("starter", (uiManager.SceneFadeingSpeed + (uiManager.AnimSpeed * 4)));
        Invoke("typing", (uiManager.SceneFadeingSpeed + (uiManager.AnimSpeed * 4)));
    }

    void starter()
    {
        if(SignUp.activeSelf == false)
            SignUp.SetActive(true);
        StartCoroutine(FirstCP());
    }

    void repeatFirst()
    {
        StartCoroutine(FirstCP());
    }

    void repeatSecond()
    {
        StartCoroutine(SecondCP());
    }

    IEnumerator FirstCP()
    {
        WaitForSeconds wait =  new WaitForSeconds(AnimSpeed * 2);
        
        for(o=0; o <3; o++)
        {
            Debug.Log("Count");
            yield return wait;

            chats[o].SetActive(true);

            chatCG = chats[o].GetComponent<CanvasGroup>();
            DOTween.To(() => chatCG.alpha, x => chatCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuart);           
        }

        yield return wait;

        Typing.SetActive(false);

        OptionContainer.SetActive(true);
        OptionContainerCG = OptionContainer.GetComponent<CanvasGroup>();
        DOTween.To(() => OptionContainerCG.alpha, x => OptionContainerCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuart);
    }


    IEnumerator SecondCP()
    {
        Debug.Log("SecondCP");

        WaitForSeconds wait = new WaitForSeconds(AnimSpeed * 2);

        for (o = 3; o < 4; o++)
        {
            Debug.Log("Count");
            yield return wait;

            chats[3].SetActive(true);

            chatCG = chats[3].GetComponent<CanvasGroup>();
            DOTween.To(() => chatCG.alpha, x => chatCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuart);
        }

        yield return wait;

        Typing.SetActive(false);

        InputContainerOne.SetActive(true);
        InputContainerOneCG = InputContainerOne.GetComponent<CanvasGroup>();
        DOTween.To(() => InputContainerOneCG.alpha, x => InputContainerOneCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuart);
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
        mySequence.Append(DOTween.To(() => OptionContainerCG.alpha, x => OptionContainerCG.alpha = x, 0, AnimSpeed / 2).SetEase(Ease.InQuart))
            .Append(DOTween.To(() => AnswerOneCG.alpha, x => AnswerOneCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuart));

        StartCoroutine(SecondCP());
        Invoke("typing", AnimSpeed*2);
    }

    public void OptionTwo()
    {
        AnswerTwo.SetActive(true);

        AnswerTwoCG = AnswerTwo.GetComponent<CanvasGroup>();
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(DOTween.To(() => OptionContainerCG.alpha, x => OptionContainerCG.alpha = x, 0, AnimSpeed / 2).SetEase(Ease.InQuart))
            .Append(DOTween.To(() => AnswerTwoCG.alpha, x => AnswerTwoCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuart));

        StartCoroutine(SecondCP());
        Invoke("typing", AnimSpeed);
    }

    // StartCoroutine(InvokeManagerMethods());

    //conversation finished
    IEnumerator InvokeManagerMethods()
    {
        yield return new WaitForSeconds(AnimSpeed * 3);

        uiManagerTItle.ZoomindText();
        uiManagerDockBar.CalendarCanvas();
        uiManagerDockBar.ShowDockBar();
        uiManager.BotOnOff();

    }
}
