﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerTimeIsUp : MonoBehaviour
{
    public int countDownStartValue = 89;
    public TextMeshProUGUI Countdown;
    string addZero = "";
    public GameObject preCount;
    public GameObject Portal;


    


    public void countDownTimer()
    {
        if(countDownStartValue > 0)
        {
            if (countDownStartValue == 88)
            {
                
                preCount.SetActive(false); // the script TimerTimeIsUp gets enabled
                GameObject MainCamera = GameObject.Find("Main Camera"); // the script finds the Camera
                MainCamera.GetComponent<MultipleTargetCamera>().enabled = true;
            }

            if (countDownStartValue == 24)
            {
                Portal.GetComponent<Portal>().SoundChargeUp();
            }

            if (countDownStartValue < 11)
            {
                Portal.GetComponent<Portal>().OpeningPortal();
            }

            if (countDownStartValue == 10)
            {
                 Portal.GetComponent<Portal>().fullyCharged = true;

            }


            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            Countdown.text = "Time Left: " + spanTime.Minutes + ":" + addZero + spanTime.Seconds; ;
            if (spanTime.Seconds<11 && spanTime.Seconds>0)
            {
                addZero = "0";
            }else { addZero = ""; }
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            Countdown.text = "Time is up!";
            FindObjectOfType<GameManager>().TimeUp(); // execute void TimeUp() in the GameManager script
        }
    }


   

}
