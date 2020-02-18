using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems; // Required when using event data
using UnityEngine.UI;
using DG.Tweening;

public class AutoScroll : MonoBehaviour, IEndDragHandler // required interface when using the OnEndDrag method.
{
    [Range(0f, 5f)]
    public float ScrollSpeed;

    public float StartPosY;
    private float StartPosX;
    private float CurrentPos;

    public ScrollRect scrollRect;

    private void Start()
    {
        ScrollSpeed = 1.6f;

        StartPosX = scrollRect.content.localPosition.x;
        StartPosY = scrollRect.content.localPosition.y;
    }

    //Do this when the user stops dragging this UI Element.
    public void OnEndDrag(PointerEventData data)
    {
        CurrentPos = scrollRect.content.localPosition.y;

        //if (CurrentPos > StartPosY)
        //    Debug.Log("Stopped dragging " + this.name + "!");
    }

    public void SrollUp()
    {  
        DOTween.To(() => CurrentPos, x => CurrentPos = x, StartPosY, ScrollSpeed).SetEase(Ease.OutCubic);
        scrollRect.content.localPosition = new Vector2(StartPosX, StartPosY);
    }
      
}