using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private InventoryManager inventory;
    [SerializeField] private RootManager rootManager;
    
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

    [Header("Connected Items")] 
    [SerializeField] private Item[] connectedItems;

    [Header("Item States")] 
    [SerializeField] private Color hiddenColor;
    [SerializeField] private Color glowColor;
    [SerializeField] private Color availableColor;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button itemButton;

    private void Start()
    {
        itemImage.color = hiddenColor;
        itemButton.interactable = false;
    }

    public void OnHoverEnter()
    {
        foreach (var item in connectedItems)
        {
            if (item.needSpike && inventory.hasSpike)
            {
                item.SetGlow();
            }
            else if (item.needStink && inventory.hasStink)
            {
                item.SetGlow();
            }
            else if (item.needDrill && inventory.hasDrill)
            {
                item.SetGlow();
            }
            else if (item.needHealth && inventory.hasHealth)
            {
                item.SetGlow();
            }
            else if(!item.needDrill && !item.needStink && !item.needDrill)
            {
                item.SetGlow();
            }
        }
    }
    
    public void OnHoverExit()
    {
        foreach (var item in connectedItems)
        {
            item.HideImage();
        }
    }

    public void OnItemSelected()
    {
        //Todo Count down for length of item held
        //Initiate completion after held time
        //Start a timer
        SelectionComplete();
    }

    public void ItemDeselected()
    {
        //If time to complete has not be set yet, undo based on amount of time used
    }

    private void SelectionComplete()
    {
        //Mark Time Manager
        //Set the item's properties (branching or powerup)
        if (hasDrill)
        {
            inventory.hasDrill = true;
            //change plant state
        }
        if (hasStink)
        {
            inventory.hasStink = true;
            //move mouse
            //change plant state
        }
        if (hasSpike)
        {
            inventory.hasSpike = true;
            //change plant state
        }

        if (hasHealth)
        {
            inventory.hasHealth = true;
            //change plant state
        }

        if (hasMusic)
        {
            //change music
        }
        
        if (hasBranches)
        {
            foreach (var item in connectedItems)
            {
                if (item.needSpike && inventory.hasSpike)
                {
                    item.ItemAvailable();
                    rootManager.ShowRoot(this.name + "+" + item.name);
                    if (isWin)
                    {
                        //GameManager win condition if(drill...
                    }
                }
                else if (item.needStink && inventory.hasStink)
                {
                    item.ItemAvailable();
                    rootManager.ShowRoot(this.name + "+" + item.name);
                    if (isWin)
                    {
                        //GameManager win condition if(drill...
                    }
                }
                else if (item.needDrill && inventory.hasDrill)
                {
                    item.ItemAvailable();
                    rootManager.ShowRoot(this.name + "+" + item.name);
                    if (isWin)
                    {
                        //GameManager win condition if(drill...
                    }
                }
                else if(!item.needDrill && !item.needStink && !item.needDrill)
                {
                    item.ItemAvailable();
                    rootManager.ShowRoot(this.name + "+" + item.name);
                    if (isWin)
                    {
                        //GameManager win condition if(drill...
                    }
                }
            }
        }
        
        //Check Time Manager
    }

    public void SetGlow()
    {
        itemImage.color = glowColor;
    }

    public void HideImage()
    {
        itemImage.color = hiddenColor;
    }
    
    public void ItemAvailable()
    {
        itemImage.color = availableColor;
        itemButton.interactable = true;
        
    }
}
