using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    private int dayIndex = 0;
    private int dayMax = 6;
    private bool changingDay = false;

    [SerializeField]
    private DayNightControl dayNightControl;
    [SerializeField]
    private Toggle[] calendarDays;

    [SerializeField] private GameManager gm;
    [SerializeField] private Animator plantAnimator;
    
    //use this bool to check if we're in the middle of a transition or not
    public bool ChangingDay {
        get { return changingDay; }
    }

    public IEnumerator AdvanceDay()
    {
        if (!changingDay && dayIndex < dayMax)
        {
            changingDay = true;
            if(calendarDays.Length > 2) 
                calendarDays[dayIndex].isOn = true;
            dayIndex++;
            plantAnimator.SetInteger("Phase", dayIndex);
            dayNightControl.ChangeToNight();
            yield return new WaitForSeconds(dayNightControl.CycleTime()*2);
            changingDay = false;
            //gm.CloseCover();
        }
        else if (!changingDay && dayIndex == dayMax)
        {
            //lose condition?
            //trigger garbage truck animation and then lose screen
        }
    }

    void Update()
    {
        //Debug.Log("Changing day? " + changingDay + " dayIndex: " + dayIndex);
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(AdvanceDay());
        }
    }

    public int CheckDay()
    {
        return dayIndex;
    }
}
