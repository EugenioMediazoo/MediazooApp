using UnityEngine;
using System.Collections;

public class UrlButton : MonoBehaviour
{

    public string URL;
    public void OpenURL()
    {
        Application.OpenURL(URL);
        Debug.Log("is this working?");
    }

}
