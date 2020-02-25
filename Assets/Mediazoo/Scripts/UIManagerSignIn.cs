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

    //private void Start()
    //{
    //    Invoke("starter", 0);
    //    Invoke("typing", 0);
    //}

    //public void MyFunction()
    //{
    //    chats[o].SetActive(true);
    //    //Debug.Log(chats[o].name);

    //    chatCG = chats[o].GetComponent<CanvasGroup>();

    //    //Debug.Log("Before" + chatCG.name + "alpha " + chatCG.alpha);
    //    DOTween.To(() => chatCG.alpha, x => chatCG.alpha = x, 1, 0.5f).SetEase(Ease.InCubic).OnComplete(MyFunction)/*.SetDelay(2)*/;
    //    //Debug.Log("After" + chatCG.name + "alpha " +  chatCG.alpha);

    //    o++;
    //}

    //public void Ready()
    //{
    //    Invoke("starter", 0);
    //    Invoke("typing", 0);
    //}

    public void starter()
    {
        SignIn.SetActive(true);
        Invoke("typing", 0);

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
            DOTween.To(() => chatCG.alpha, x => chatCG.alpha = x, 1, 0.5f).SetEase(Ease.InQuart).OnComplete(starter)/*.SetDelay(2)*/;
            //Debug.Log("After" + chatCG.name + "alpha " +  chatCG.alpha);

            o++;
        }
        else
        {
            Typing.SetActive(false);
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
}
