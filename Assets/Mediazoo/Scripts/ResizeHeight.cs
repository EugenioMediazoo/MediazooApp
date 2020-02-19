using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeHeight : MonoBehaviour
{
    public RectTransform Container;
    public RectTransform Child;

    // Start is called before the first frame update
    void Start()
    {
        float ContainerWidthX;
        ContainerWidthX = Container.sizeDelta.x;
        Container.sizeDelta = new Vector2(ContainerWidthX, (ContainerWidthX * 0.5625f));
        Invoke("changeChild", 1);
        //ratio  1080/1920 = 0.5625
    }

    public void changeChild()
    {
        Child.sizeDelta = new Vector2(Container.sizeDelta.x, Container.sizeDelta.y);
    }

}
