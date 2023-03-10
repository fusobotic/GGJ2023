using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    private int dayIndex = 0;
    private int dayMax = 6;
    private bool changingDay = false;

    [SerializeField]
    private DayNightControl dayNightControl;

    [SerializeField] private GameObject[] calendarDays;
    //private Toggle[] calendarDays;

    [SerializeField] private GameManager gm;
    [SerializeField] private Animator plantAnimator;
    [SerializeField] private Animator truckAnimator;
    [SerializeField] private CinemachineVirtualCamera CamUp;
    [SerializeField] private CinemachineVirtualCamera CamZoom;
    [SerializeField] private GameObject[] trashToPickup;
    [SerializeField] private GameObject sapling;
    [SerializeField] private GameObject wastedScreen;
    //use this bool to check if we're in the middle of a transition or not
    public bool ChangingDay {
        get { return changingDay; }
    }

    public IEnumerator GameStart()
    {
        CamUp.Priority = 100;
        yield return new WaitForSeconds(3f);
        CamUp.Priority = 0;
    }

    public void StartGame()
    {
        StartCoroutine(GameStart());
    }

    public IEnumerator AdvanceDay()
    {
        if (!changingDay && dayIndex < dayMax)
        {
            CamUp.Priority = 100;
            changingDay = true;
            if(calendarDays.Length > 2) 
                calendarDays[dayIndex].SetActive(true);
            dayIndex++;
            plantAnimator.SetInteger("Phase", dayIndex);
            dayNightControl.ChangeToNight();
            yield return new WaitForSeconds(dayNightControl.CycleTime()*2);
            changingDay = false;
            CamUp.Priority = 0;
            //gm.CloseCover();
        }
        else if (!changingDay && dayIndex == dayMax)
        {
            StartCoroutine(YouLose(gm.lostScreen));
        }
    }

    public void NextDay()
    {
        StartCoroutine(AdvanceDay());
    }

    public IEnumerator YouWin(GameObject winscreen)
    {
        CamUp.Priority = 100;
        truckAnimator.SetTrigger("PullUp");
        yield return new WaitForSeconds(2.75f);
        foreach (GameObject gm in trashToPickup)
        {
            gm.transform.position += new Vector3(0, 100, 0);
        }
        sapling.SetActive(true);
        yield return new WaitForSeconds(3.75f);
        CamZoom.Priority = 200;
        winscreen.SetActive(true);
    }

    public IEnumerator YouLose(GameObject losescreen)
    {
        CamUp.Priority = 100;
        truckAnimator.SetTrigger("PullUp");
        yield return new WaitForSeconds(2.75f);
        foreach (GameObject gm in trashToPickup)
        {
            gm.transform.position += new Vector3(0, 100, 0);
        }
        wastedScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        wastedScreen.SetActive(false);
        losescreen.SetActive(true);
    }

    void Update()
    {
        //Debug.Log("Changing day? " + changingDay + " dayIndex: " + dayIndex);
        if (Input.GetMouseButtonDown(0))
        {
            //StartCoroutine(AdvanceDay());
            //StartCoroutine(YouWin());
        }
    }

    public int CheckDay()
    {
        return dayIndex;
    }
}
