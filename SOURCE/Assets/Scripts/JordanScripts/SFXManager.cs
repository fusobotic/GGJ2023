using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip stink;
    [SerializeField] private AudioClip health;
    [SerializeField] private AudioClip drill;
    [SerializeField] private AudioClip spike;
    [SerializeField] private AudioClip selectMenu;
    [SerializeField] private AudioClip selectItem;

    public void PlayStink()
    {
        audio.PlayOneShot(stink);
    }
    
    public void PlayHealth()
    {
        audio.PlayOneShot(health);
    }
    
    public void PlayDrill()
    {
        audio.PlayOneShot(drill);
    }
    
    public void PlaySpike()
    {
        audio.PlayOneShot(spike);
    }
    
    public void PlaySelectMenu()
    {
        audio.PlayOneShot(selectMenu);
    }
    
    public void PlaySelectItem()
    {
        audio.PlayOneShot(selectItem);
    }
}
