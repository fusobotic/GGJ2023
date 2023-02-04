using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    private int dayIndex = 0;
    private int dayMax = 3;
    private bool changingDay = false;

    [SerializeField]
    private DayNightControl dnc;

    [SerializeField] private GameManager gm;
    
    //use this bool to check if we're in the middle of a transition or not
    public bool ChangingDay {
        get { return changingDay; }
    }

    public IEnumerator AdvanceDay()
    {
        //if (!changingDay && dayIndex <= dayMax)
        //{
            changingDay = true;
            dayIndex++;
            dnc.ChangeToNight();
            yield return new WaitForSeconds(dnc.CycleTime()*2);
            changingDay = false;
            gm.CloseCover();
        //}
        //else if (!changingDay && dayIndex > dayMax)
        //{
            //lose condition?
            //trigger garbage truck animation and then lose screen
        //}
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
