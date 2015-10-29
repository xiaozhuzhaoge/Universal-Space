﻿#if !No_Reporter
using UnityEngine;
using System.Collections;

public class ReporterMessageReceiver : MonoBehaviour
{
    Reporter reporter ;

    void Start()
    {
        reporter = gameObject.GetComponent<Reporter>();
    }

    void OnPreStart()
    {
        //To Do : this method is called before initializing reporter, 
        //we can for example check the resultion of our device ,then change the size of reporter
        if (reporter == null)
            reporter = gameObject.GetComponent<Reporter>();

        if (Screen.width < 1000)
            reporter.size = new Vector2(25, 25);
        else 
            reporter.size = new Vector2(25, 25);
    }

    void OnHideReporter()
    {
        //TO DO : resume your game
    }

    void OnShowReporter()
    {
        if (PlayerData.curCharacter != null)
        {
            reporter.UserData = "角色ID：" + PlayerData.curCharacter.id.ToString();
        } else
        {
            reporter.UserData = "角色ID：";
        }
    }

    void OnLog(Reporter.Log log)
    {
        //TO DO : put you custom code 
    }



}
#endif