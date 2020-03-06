
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManagerInstagram : MonoBehaviour
{
    //timers
    [Range(1, 20)]
    public float ReadingTime = 3;

    [Range(0f, 10f)]
    public float AnimSpeed = 0.6f;

    public GameObject[] Deck;
    private int i = 0;

    //card decks
    public GameObject R;
    //One
    public GameObject deckOne;
    private CanvasGroup deckOneCG;
    //Two
    public GameObject deckTwo;
    private CanvasGroup deckTwoCG;
    //Three
    public GameObject deckThree;
    private CanvasGroup deckThreeCG;
    //Four
    public GameObject deckFour;
    private CanvasGroup deckFourCG;
    //Five
    public GameObject deckFive;
    private CanvasGroup deckFiveCG;

    //custom
    private CanvasGroup DeckCustomCG;

    //card timer
    public Slider InstaSlider;
    private CanvasGroup InstaSliderCG;

    private string tag;

    //Values Page Content
    public GameObject ValuesContent;
    private CanvasGroup ValuesContentCG;
    
    public GameObject ValuesTitle;
    private CanvasGroup ValuesTitleCG;
    
    public GameObject UserIcon;
    private CanvasGroup UserIconCG;

    //dockbar
    public GameObject DockBar;
    private CanvasGroup DockBarCG;

    private void Awake()
    {
        deckOneCG = deckOne.GetComponent<CanvasGroup>();
        deckTwoCG = deckTwo.GetComponent<CanvasGroup>();
        deckThreeCG = deckThree.GetComponent<CanvasGroup>();
        deckFourCG = deckFour.GetComponent<CanvasGroup>();
        deckFiveCG = deckFive.GetComponent<CanvasGroup>();
        
        InstaSliderCG = InstaSlider.GetComponent<CanvasGroup>();
        ValuesContentCG = ValuesContent.GetComponent<CanvasGroup>();
        ValuesTitleCG = ValuesTitle.GetComponent<CanvasGroup>();
        UserIconCG = UserIcon.GetComponent<CanvasGroup>();
        DockBarCG = DockBar.GetComponent<CanvasGroup>();
    }

    public void FirstDeck()
    {
        tag = "DeckOne";
        Invoke("findCards", 0);
        DeckCustomCG = deckOneCG;
    }
    public void SecondDeck()
    {
        tag = "DeckTwo";
        Invoke("findCards", 0);
        DeckCustomCG = deckTwoCG;
    }
    public void ThirdDeck()
    {
        tag = "DeckThree";
        Invoke("findCards", 0);
        DeckCustomCG = deckThreeCG;
    }
    public void FourthDeck()
    {
        tag = "DeckFour";
        Invoke("findCards", 0);
        DeckCustomCG = deckFourCG;
    }
    public void FifthDeck()
    {
        tag = "DeckFive";
        Invoke("findCards", 0);
        DeckCustomCG = deckFiveCG;
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
        InstaSlider.maxValue = ReadingTime;
        if (InstaSlider.value != 0)
            InstaSlider.value = 0;
         
        DOTween.To(() => DeckCustomCG.alpha, x => DeckCustomCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuad);
        DOTween.To(() => InstaSliderCG.alpha, x => InstaSliderCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuad);

        DOTween.To(() => ValuesContentCG.alpha, x => ValuesContentCG.alpha = x, 0, AnimSpeed).SetEase(Ease.InQuad);
        DOTween.To(() => ValuesTitleCG.alpha, x => ValuesTitleCG.alpha = x, 0, AnimSpeed).SetEase(Ease.InQuad);
        DOTween.To(() => UserIconCG.alpha, x => UserIconCG.alpha = x, 0, AnimSpeed).SetEase(Ease.InQuad);
        DOTween.To(() => DockBarCG.alpha, x => DockBarCG.alpha = x, 0, AnimSpeed).SetEase(Ease.InQuad);

        bool raycasteable = true;

        if(raycasteable)
        {
            DeckCustomCG.interactable = true;
            DeckCustomCG.blocksRaycasts = true;
        }
        else if (!raycasteable)
        {
            DeckCustomCG.interactable = false;
            DeckCustomCG.blocksRaycasts = false;

            raycasteable =! raycasteable;
        }
     }

    IEnumerator OneAtTheTime()
    {

        for (i = 0; i < Deck.Length; i++)
        {
            if (i + 1 < Deck.Length)
            {
                Sequence mySequenceSlider = DOTween.Sequence()
                    .Append(DOTween.To(() => InstaSlider.value, x => InstaSlider.value = x, ReadingTime, ReadingTime))
                    .Append(DOTween.To(() => InstaSlider.value, x => InstaSlider.value = x, 0, 0));

                WaitForSeconds waitLoad = new WaitForSeconds(ReadingTime);
                yield return waitLoad;

                Sequence mySequence = DOTween.Sequence();
                mySequence.Append(Deck[i].transform.DOMoveX((R.transform.position.x * 0.5f) * -1, AnimSpeed)).SetEase(Ease.InOutQuad)
                    .Join(Deck[i + 1].transform.DOMoveX((R.transform.position.x * 0.5f), AnimSpeed)).SetEase(Ease.InOutQuad);
            }
            else
            {
                Sequence mySequenceSlider = DOTween.Sequence()
                    .Append(DOTween.To(() => InstaSlider.value, x => InstaSlider.value = x, ReadingTime, ReadingTime))
                    .Append(DOTween.To(() => InstaSlider.value, x => InstaSlider.value = x, 0, 0));

                WaitForSeconds waitLoad = new WaitForSeconds(ReadingTime);
                yield return waitLoad;

                Sequence mySequence = DOTween.Sequence()
                    .Append(DOTween.To(() => InstaSliderCG.alpha, x => InstaSliderCG.alpha = x, 0, 0))
                    .Join(Deck[i].transform.DOMoveX((R.transform.position.x * 0.5f) * -1, 1))
                    .Append(DOTween.To(() => DeckCustomCG.alpha, x => DeckCustomCG.alpha = x, 0, 0))
                    .Join(DOTween.To(() => ValuesContentCG.alpha, x => ValuesContentCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuad))
                    .Join(DOTween.To(() => ValuesTitleCG.alpha, x => ValuesTitleCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuad))
                    .Join(DOTween.To(() => UserIconCG.alpha, x => UserIconCG.alpha = x, 1, AnimSpeed).SetEase(Ease.InQuad))
                    .Join(DOTween.To(() => DockBarCG.alpha, x => DockBarCG.alpha = x, 0, AnimSpeed).SetEase(Ease.InQuad));

                Invoke("MakeVisible", 0);
            }
        }
    }
}
