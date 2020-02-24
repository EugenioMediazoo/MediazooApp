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

    private void Awake()
    {
        SignIn.SetActive(true);
    }

    private void Start()
    {
        //chats[o].SetActive(true);
        //Debug.Log(chats[o].name);
        //Invoke("MyFunction", 0.2f);
        StartCoroutine(MyFunctions());
    }

    public void MyFunction()
    {
        chats[o].SetActive(true);
        //Debug.Log(chats[o].name);

        chatCG = chats[o].GetComponent<CanvasGroup>();

        //Debug.Log("Before" + chatCG.name + "alpha " + chatCG.alpha);
        DOTween.To(() => chatCG.alpha, x => chatCG.alpha = x, 1, 0.5f).SetEase(Ease.InCubic).OnComplete(MyFunction)/*.SetDelay(2)*/;
        //Debug.Log("After" + chatCG.name + "alpha " +  chatCG.alpha);

        o++;
    }

    public void starter()
    {
        StartCoroutine(MyFunctions());
    }

    IEnumerator MyFunctions()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        chats[o].SetActive(true);
        //Debug.Log(chats[o].name);

        chatCG = chats[o].GetComponent<CanvasGroup>();

        //Debug.Log("Before" + chatCG.name + "alpha " + chatCG.alpha);
        DOTween.To(() => chatCG.alpha, x => chatCG.alpha = x, 1, 0.5f).SetEase(Ease.InCubic).OnComplete(starter)/*.SetDelay(2)*/;
        //Debug.Log("After" + chatCG.name + "alpha " +  chatCG.alpha);

        o++;
    }
}
