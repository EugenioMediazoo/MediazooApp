using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject Parent;

    // Start is called before the first frame update
    void Start()
    {
        var _height = this.gameObject.GetComponent<RectTransform>().sizeDelta.y;

        var PrarentWidth = Parent.GetComponent<RectTransform>().sizeDelta.x;

        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(PrarentWidth, _height);
        //Screen.width
    }

}
