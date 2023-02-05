using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject medication;
    public GameObject cheese;
    public GameObject drill;
    
    public void turnOnMedication()
    {
        medication.SetActive(true);
    }
    
    public void turnOnCheese()
    {
        cheese.SetActive(true);
    }
    
    public void turnOnDrill()
    {
        drill.SetActive(true);   
    }
    
    
}
