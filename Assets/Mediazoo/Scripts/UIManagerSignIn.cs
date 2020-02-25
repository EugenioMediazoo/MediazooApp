using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIManagerSignIn : MonoBehaviour
{
    public GameObject SignIn;

    public GameObject[] chats;
    private CanvasGroup chatCG;
    private int o = 0;

    public GameObject Typing;
    public CanvasGroup[] dotsCG;

    public GameObject AnswerOne;
    private CanvasGroup AnswerOneCG;
    public GameObject AnswerTwo;
    private CanvasGroup AnswerTwoCG;

    public GameObject OptionContainer;
    private CanvasGroup OptionContainerCG;


    public void Ready()
    {
        Invoke("starter", 2.8f);
        Invoke("typing", 2.8f);
    }

    void starter()
    {
        SignIn.SetActive(true);
        
        StartCoroutine(MyFunctions());
    }

    IEnumerator MyFunctions()
    {
        yield return new WaitForSeconds(1.2f);

        if (o < chats.Length)
        {
            chats[o].SetActive(true);
            //Debug.Log(chats[o].name);

            chatCG = chats[o].GetComponent<CanvasGroup>();

            //Debug.Log("Before" + chatCG.name + "alpha " + chatCG.alpha);
            DOTween.To(() => chatCG.alpha, x => chatCG.alpha = x, 1, 0.5f).SetEase(Ease.InQuart).OnComplete(starter);
            //Debug.Log("After" + chatCG.name + "alpha " +  chatCG.alpha);

            o++;
        }
        else
        {
            Typing.SetActive(false);

            OptionContainer.SetActive(true);
            OptionContainerCG = OptionContainer.GetComponent<CanvasGroup>();
            DOTween.To(() => OptionContainerCG.alpha, x => OptionContainerCG.alpha = x, 1, 0.5f).SetEase(Ease.InQuart);
            yield break;
        }
    }

    public void typing()
    {
        Typing.SetActive(true);

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(DOTween.To(() => dotsCG[0].alpha, x => dotsCG[0].alpha = x, 0.8f, 0.2f).SetEase(Ease.InOutQuint).SetLoops(0, LoopType.Yoyo))
            .Append(DOTween.To(() => dotsCG[1].alpha, x => dotsCG[1].alpha = x, 0.8f, 0.2f).SetEase(Ease.InOutQuint).SetLoops(0, LoopType.Yoyo))
            .Append(DOTween.To(() => dotsCG[2].alpha, x => dotsCG[2].alpha = x, 0.8f, 0.2f).SetEase(Ease.InOutQuint).SetLoops(0, LoopType.Yoyo))
            .SetLoops(-1);
    }

    public void OptionOne()
    {
        AnswerOne.SetActive(true);

        AnswerOneCG = AnswerOne.GetComponent<CanvasGroup>();
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(DOTween.To(() => OptionContainerCG.alpha, x => OptionContainerCG.alpha = x, 0, 0.5f).SetEase(Ease.InQuart))
            .Append(DOTween.To(() => AnswerOneCG.alpha, x => AnswerOneCG.alpha = x, 1, 0.5f).SetEase(Ease.InQuart));
    }

    public void OptionTwo()
    {
        AnswerTwo.SetActive(true);

        AnswerTwoCG = AnswerTwo.GetComponent<CanvasGroup>();
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(DOTween.To(() => OptionContainerCG.alpha, x => OptionContainerCG.alpha = x, 0, 0.5f).SetEase(Ease.InQuart))
            .Append(DOTween.To(() => AnswerTwoCG.alpha, x => AnswerTwoCG.alpha = x, 1, 0.5f).SetEase(Ease.InQuart));
    }
}
