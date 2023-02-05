using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startWindow;
    [SerializeField] private Item startItem;
    //[SerializeField] private GameObject garbageOverlay;
    [SerializeField] private DayCounter dayCounter;
    [SerializeField] private GameObject winScreen;
    [SerializeField] public GameObject lostScreen;
    [SerializeField] private int maxDay = 8;
    //[SerializeField] private GameObject uiCover;
    

    public void HasWin()
    {
        StartCoroutine(dayCounter.YouWin(winScreen));
    }

    private void HasLost()
    {
        StartCoroutine(dayCounter.YouLose(lostScreen));
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGameButton()
    {
        startWindow.SetActive(false);
        startItem.ItemAvailable();
        dayCounter.StartGame();
    }

    public void CheckDay()
    {
        if (dayCounter.CheckDay() < maxDay)
        {
            //uiCover.SetActive(true);
            dayCounter.NextDay();
        }
        else
        {
            HasLost();
        }
    }

    public void CloseCover()
    {
        //uiCover.SetActive(false);
    }
}
