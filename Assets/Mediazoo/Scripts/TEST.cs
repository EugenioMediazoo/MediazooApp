using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TEST : MonoBehaviour
{

    public GameObject[] Cards;
    private int i = 0;


    //public GameObject Next;
   // public GameObject Next2;

    public GameObject R;


    void Awake()
    {
       // Current.transform.DOMoveX((R.transform.position.x * 1.5f), 0);
    }


    void Start()
    {
       // Current.transform.DOMoveX(C.transform.position.x, 0);
        //Next.transform.DOMoveX((R.transform.position.x*1.5f), 0);
        //Next2.transform.DOMoveX((R.transform.position.x * 1.5f), 0);

        foreach (GameObject card in Cards)
        {
            card.transform.DOMoveX((R.transform.position.x * 1.5f), 0);
        }

        Cards[0].transform.DOMoveX(R.transform.position.x*0.5f, 0);
    }

    public void moveL()
    {
        for (i = 0; i < Cards.Length; i++)
        {
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(Cards[i].transform.DOMoveX((R.transform.position.x * 0.5f) * -1, 1))
            .Join(Cards[i + 1].transform.DOMoveX((R.transform.position.x * 0.5f), 1));
        }

        //Sequence mySequence = DOTween.Sequence();
        //mySequence.Append(Current.transform.DOMoveX((R.transform.position.x * 0.5f) * -1, 1))
        //.Join(Next.transform.DOMoveX((R.transform.position.x *0.5f), 1))
        //.Join(Next2.transform.DOMoveX((R.transform.position.x * 0.5f), 1));
    }

    //public void moveR()
    //{
    //    Sequence mySequence = DOTween.Sequence();
    //    mySequence.Append(Current.transform.DOMoveX(R.transform.position.x * 0.5f, 1))
    //    .Join(Next.transform.DOMoveX(R.transform.position.x * 1.5f, 1));

    //}
}
