
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManagerInstagram : MonoBehaviour
{
    [Range(1, 20)]
    public float ReadingTime = 3;

    [Range(0f, 10f)]
    public float AnimSpeed = 0.6f;

    public GameObject[] Deck;
    private int i = 0;

    public GameObject R;
    public GameObject deckOne;
    private CanvasGroup deckOneCG;

    public string tag;
    
    public void FirstDeck()
    {
        tag = "DeckOne";
        Invoke("findCards", 0);
    }
    public void SecondDeck()
    {
        tag = "DeckTwo";
        Invoke("findCards", 0);
    }
    public void ThirdDeck()
    {
        tag = "DeckThree";
    }
    public void FourthDeck()
    {
        tag = "DeckFour";
    }
    public void FifthDeck()
    {
        tag = "DeckFive";
    }

    private void Awake()
    {
        deckOneCG = deckOne.GetComponent<CanvasGroup>();
    }

    void findCards()
    {
        Deck = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject Card in Deck)
        {
            Card.SetActive(true);
            Card.transform.DOMoveX((R.transform.position.x * 1.5f), 0);
        }

        Deck[0].transform.DOMoveX(R.transform.position.x * 0.5f, 0);

        StartCoroutine(OneAtTheTime());
    }

     public void MakeVisible()
    {
        DOTween.To(() => deckOneCG.alpha, x => deckOneCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuad);
    }

    IEnumerator OneAtTheTime()
    {
        WaitForSeconds wait = new WaitForSeconds(1);

        for (i = 0; i < Deck.Length; i++)
        {
            WaitForSeconds waitLoad = new WaitForSeconds(ReadingTime);
            yield return waitLoad;

            if (i + 1 < Deck.Length)
            {
                Sequence mySequence = DOTween.Sequence();
                mySequence.Append(Deck[i].transform.DOMoveX((R.transform.position.x * 0.5f) * -1, AnimSpeed)).SetEase(Ease.InOutQuad)
                    .Join(Deck[i + 1].transform.DOMoveX((R.transform.position.x * 0.5f), AnimSpeed)).SetEase(Ease.InOutQuad);
            }
            else
                Deck[i].transform.DOMoveX((R.transform.position.x * 0.5f) * -1, 1);
        }

        //yield return wait;
    }
}
