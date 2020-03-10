using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerContentResizer : MonoBehaviour
{
    public RectTransform ContentMain;

    public Vector2 Reminder;
    public Vector2 Values;
    public Vector2 Team;
    public Vector2 User;

    // Start is called before the first frame update
    void Start()
    {
        ContentMain.sizeDelta = Reminder;
    }

    public void ContentReminder()
    {
        ContentMain.sizeDelta = Reminder;
    }

    public void ContentViewer()
    {
       //ContentMain.sizeDelta = User;
    }

    public void ContentValues()
    {
        ContentMain.sizeDelta = Values;
    }

    public void ContentTeam()
    {
        ContentMain.sizeDelta = Team;
    }

    public void ContentUser()
    {
        ContentMain.sizeDelta = User;
    }
}
