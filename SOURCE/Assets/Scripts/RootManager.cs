using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootManager : MonoBehaviour
{
    [SerializeField] private string[] comboNames;
    [SerializeField] private GameObject[] roots;

    private void Start()
    {
        foreach (var root in roots)
        {
            root.SetActive(false);
        }
    }

    public void ShowRoot(string s)
    {
        roots[Array.IndexOf(comboNames, s)].SetActive(true);
    }
}
