using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject ReminderMessages;

    public void Awake()
    {
        ReminderMessages.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        //Reminders.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
