using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private InventoryManager inventory;
    [SerializeField] private RootManager rootManager;
    [SerializeField] private GameManager gm;
    [SerializeField] private SFXManager sfx;
    
    [Header("Item Quality")]
    [SerializeField] private bool hasSpike;
    [SerializeField] private bool hasStink;
    [SerializeField] private bool hasDrill;
    [SerializeField] private bool hasBranches;
    [SerializeField] private bool hasHealth;
    [SerializeField] private bool hasMusic;
    [SerializeField] private bool isWin;
    
    [Header("Item Needs")]
    public bool needSpike;
    public bool needStink;
    public bool needDrill;
    public bool needHealth;
    public bool plainItem;
    public bool hasGarbage;
    
    [Header("Connected Items")] 
    [SerializeField] private Item[] connectedItems;
    [SerializeField] private GameObject garbage;
    
    [Header("Item States")] 
    [SerializeField] private Color hiddenColor;
    [SerializeField] private Color glowColor;
    [SerializeField] private Color availableColor;
    [SerializeField] private Color completedColor;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button itemButton;

    private bool itemUsed = false;
    private bool isAvailable = false;
    
    private void Start()
    {
        itemImage.color = hiddenColor;
        itemButton.interactable = false;
    }

    public void OnHoverEnter()
    {
        if (!itemUsed && isAvailable)
        {
            foreach (var item in connectedItems)
            {
                if (item.needSpike && inventory.hasSpike)
                {
                    item.SetGlow();
                    //item.garbage.GetComponent<Image>().color = hiddenColor;
                    continue;
                }
            
                if (item.needStink && inventory.hasStink)
                {
                    item.SetGlow();
                    continue;
                }
            
                if (item.needDrill && inventory.hasDrill)
                {
                    item.SetGlow();
                    continue;
                }
            
                if (item.needHealth && inventory.hasHealth)
                {
                    item.SetGlow();
                    continue;
                }
            
                if(item.plainItem)
                {
                    item.SetGlow();
                    continue;
                }
            }
        }
        
    }
    
    public void OnHoverExit()
    {
        if (!itemUsed && !isAvailable)
        {
            foreach (var item in connectedItems)
            {
                item.HideImage();
                //if(item.hasGarbage) item.garbage.GetComponent<Image>().color = availableColor;
            }
        }
        
    }

    public void OnItemSelected()
    {
        //Todo Count down for length of item held
        //Initiate completion after held time
        //Start a timer
        SelectionComplete();
        sfx.PlaySelectItem();
    }

    public void ItemDeselected()
    {
        //If time to complete has not be set yet, undo based on amount of time used
    }

    private void SelectionComplete()
    {
        bool hasWin = false;
        itemUsed = true;
        itemImage.color = completedColor;
        itemButton.interactable = false;
        //Mark Time Manager
        //Set the item's properties (branching or powerup)
        if (hasDrill)
        {
            inventory.hasDrill = true;
            GameObject.FindObjectOfType<ParticleManager>().GetComponent<ParticleManager>().turnOnDrill();
            sfx.PlayDrill();
            //change plant state
        }
        if (hasStink)
        {
            inventory.hasStink = true;
            GameObject.FindObjectOfType<ParticleManager>().GetComponent<ParticleManager>().turnOnCheese();
            sfx.PlayStink();
        }
        if (hasSpike)
        {
            inventory.hasSpike = true;
            sfx.PlaySpike();
        }

        if (hasHealth)
        {
            inventory.hasHealth = true;
            GameObject.FindObjectOfType<ParticleManager>().GetComponent<ParticleManager>().turnOnMedication();
            sfx.PlayHealth();
        }

        if (hasMusic)
        {
            //change music
            GameObject.FindObjectOfType<MusicManager>().GetComponent<MusicManager>().SwitchMusic();
        }
        
        if (hasBranches)
        {
            
            foreach (var item in connectedItems)
            {
                if (item.needSpike && inventory.hasSpike)
                {
                    item.ItemAvailable();
                    rootManager.ShowRoot(this.name + "+" + item.name);
                    if (item.isWin)
                    {
                        hasWin = true;
                        break;
                    }

                    continue;
                }
                
                if (item.needStink && inventory.hasStink)
                {
                    item.ItemAvailable();
                    rootManager.ShowRoot(this.name + "+" + item.name);
                    if (item.isWin)
                    {
                        hasWin = true;
                        break;
                    }
                    continue;
                }
                
                if (item.needDrill && inventory.hasDrill)
                {
                    item.ItemAvailable();
                    rootManager.ShowRoot(this.name + "+" + item.name);
                    if (item.isWin)
                    {
                        hasWin = true;
                        break;
                    }
                    continue;
                }
                
                if (item.needHealth && inventory.hasHealth)
                {
                    item.ItemAvailable();
                    rootManager.ShowRoot(this.name + "+" + item.name);
                    if (item.isWin)
                    {
                        hasWin = true;
                        break;
                    }
                    continue;
                }
                
                if(item.plainItem)
                {
                    item.ItemAvailable();
                    rootManager.ShowRoot(this.name + "+" + item.name);
                    if (item.isWin)
                    {
                        hasWin = true;
                        break;
                    }
                    continue;
                }
            }

            
        }
        if (hasWin)
        {
            gm.HasWin();
        }
        else
        {
            gm.CheckDay();
        }
    }

    public void SetGlow()
    {
        if(!itemUsed) itemImage.color = glowColor;
    }

    public void HideImage()
    {
        if(!itemUsed) itemImage.color = hiddenColor;
    }
    
    public void ItemAvailable()
    {
        if (!itemUsed)
        {
            if(hasGarbage) garbage.SetActive(false);
            isAvailable = true;
            itemImage.color = availableColor;
            itemButton.interactable = true;
        }
    }
}
