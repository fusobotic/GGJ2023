using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootManager : MonoBehaviour
{
    [SerializeField] private string[] comboNames;
    [SerializeField] private GameObject[] roots;

    public void ShowRoot(string s)
    {
        roots[Array.IndexOf(comboNames, s)].SetActive(true);
    }
}
