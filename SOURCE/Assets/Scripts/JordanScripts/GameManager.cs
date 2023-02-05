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
    [SerializeField] private GameObject lostScreen;
    [SerializeField] private int maxDay = 8;
    //[SerializeField] private GameObject uiCover;
    

    public void HasWin()
    {
        //Dump truck animation
        winScreen.SetActive(true);
    }

    private void HasLost()
    {
        //Dump truck animation
        lostScreen.SetActive(true);
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
