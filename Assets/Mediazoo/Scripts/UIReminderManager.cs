using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class UIReminderManager : MonoBehaviour
{

    public GameObject[] ImportantReminders;
    public GameObject[] UpcomingReminders;
    public GameObject[] OtherReminders;

    public TextMeshProUGUI RemindersTX;
    public TextMeshProUGUI ImportantTX;
    public TextMeshProUGUI UpcomingTX;

    public void Important()
    {
        RemindersTX.color = new Color32(148, 148, 148, 255);
        ImportantTX.color = new Color32(26, 28, 46, 255);
        UpcomingTX.color = new Color32(148, 148, 148, 255);

        foreach (GameObject IR in ImportantReminders)
        {
            if(IR.activeSelf == false)
                IR.SetActive(true);
        }

        foreach (GameObject UR in UpcomingReminders)
        {
            UR.SetActive(false);
        }

        foreach (GameObject OR in OtherReminders)
        {
            OR.SetActive(false);
        }
    }

   
    public void Urgent()
    {
        RemindersTX.color = new Color32(148, 148, 148, 255);
        ImportantTX.color = new Color32(148, 148, 148, 255);
        UpcomingTX.color =  new Color32(26, 28, 46, 255);

        foreach (GameObject IR in ImportantReminders)
        {
                IR.SetActive(false);
        }

        foreach (GameObject UR in UpcomingReminders)
        {
            if (UR.activeSelf == false)
                UR.SetActive(true);
        }

        foreach (GameObject OR in OtherReminders)
        {
            OR.SetActive(false);
        }
    }

    public void Other()
    {
        RemindersTX.color = new Color32(26, 28, 46, 255);
        ImportantTX.color = new Color32(148, 148, 148, 255);
        UpcomingTX.color = new Color32(148, 148, 148, 255);

        foreach (GameObject IR in ImportantReminders)
        {
            if (IR.activeSelf == false)
                IR.SetActive(true);
        }

        foreach (GameObject UR in UpcomingReminders)
        {
            if (UR.activeSelf == false)
                UR.SetActive(true);
        }

        foreach (GameObject OR in OtherReminders)
        {
            if (OR.activeSelf == false)
                OR.SetActive(true);
        }
    }
}
