using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

//First day of gameplay to be 1/4/2076
public class TimeKeeper : MonoBehaviour
{

    public double totalGameSeconds;
    public Text time;
    public Text date;

    public double seconds;
    public double minutes;
    public double hours;
    public double days;
    public double months;
    public double years;

    public double secondsPerSecond;

    public bool timeUp = false;

    void Start()
    {

        //secondsPerSecond = 360;
        totalGameSeconds += secondsPerSecond * Time.deltaTime;


    }


    void Update()
    {
        if(!timeUp)
        {
            totalGameSeconds += secondsPerSecond * Time.deltaTime;

            int currentSeconds = (int)totalGameSeconds;

            seconds = currentSeconds;

            minutes = currentSeconds % 60;
            hours = currentSeconds / 60 % 60;
        }

        //days = currentSeconds / (60 * 60) % 24;
        //months = currentSeconds / (60 * 60 * 24) % 30;
        //years = currentSeconds / (60 * 60 * 24 * 30) % 12;
        if (hours == 24)
        {
            totalGameSeconds = 0;
            hours = 0;
            days += 1;
        }

        if (days < 4)
        {
            date.text = String.Format("{0}/{1}/{2}", days, months, years);
            time.text = String.Format("{0}:{1}", hours, minutes);
        }
        else
        {
            
            time.text = "Time Is Up!";
            timeUp = true;
        }
        //seconds = seconds - minutes - hours;
;


    }

}
