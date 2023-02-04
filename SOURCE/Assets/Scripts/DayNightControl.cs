using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DayNightControl : MonoBehaviour
{
    [SerializeField] private float dayRotation = 60;
    [SerializeField] private float nightRotation = -60;
    [SerializeField] private float cycleTime = 3f;

    public float CycleTime()
    {
        return cycleTime;
    }
    public void ChangeToNight()
    {
        transform.DORotate(new Vector3(nightRotation,-225.398f, 8.737f), cycleTime).OnComplete(ChangeToDay);
        //maybe trigger some sounds here
    }
    
    private void ChangeToDay()
    {
        transform.DORotate(new Vector3(dayRotation,-225.398f, 8.737f), cycleTime).SetEase(Ease.OutExpo);
        //maybe trigger some sounds here
    }
}
