using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private GameObject funkAudio;
    [SerializeField] private GameObject underAudio;
    [SerializeField] private GameObject aboveAudio;

    public void SwitchMusic()
    {
        underAudio.SetActive(false);
        aboveAudio.SetActive(false);
        funkAudio.SetActive(false);
    }
}
