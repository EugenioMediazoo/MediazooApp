using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIReminderManager : MonoBehaviour
{

    public GameObject[] ImportantReminders;
    public GameObject[] UpcomingReminders;
    public GameObject[] OtherReminders;


    public void Important()
    {
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
