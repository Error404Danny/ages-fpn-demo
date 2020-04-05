using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Assigning a key here will lock the door. If player has the key in their inventory, door will be unlocked")]
    [SerializeField]
    private InventoryObject storageKey;

    [Tooltip("If this is Checked, then the named key will be removed from the player's inventory when the door is unlocked")]
    [SerializeField]
    private bool consumeKey;

    [Tooltip("Text when Player looks at Locked Doors")]
    [SerializeField]
    private string lockedDoorText = "Locked";

    [Tooltip("Audio plays when Player interacts with Locked Door")]
    [SerializeField]
    private AudioClip lockedDoorAudio;

    [Tooltip("Audio plays when Player interacts with an unlocked Door")]
    [SerializeField]
    private AudioClip unlockedDoorAudio;

    //public override string DisplayText => isLocked ? lockedDoorText : base.DisplayText;

    public override string DisplayText
    {
        get
        {
            string toReturn;

            if (isLocked)
                toReturn = HasKey ? $"Use {storageKey.ObjectName}" : lockedDoorText;
            else
                toReturn = base.DisplayText;
            return toReturn;
        }
    }
    private bool HasKey => PlayerInventory.InventoryObjects.Contains(storageKey);
    private Animator animator;
    private bool isOpen = false;
    private bool isLocked;
    /// <summary>
    /// Using a Constructor here to initilize displayText in the editor
    /// </summary>
    private Door()
    {
        displayText = nameof(Door);
    }
        
    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        InitializeisLocked();
    }

    private void InitializeisLocked()
    {
        if (storageKey != null)
        {
            isLocked = true;
        }
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if (isLocked && !HasKey)
            {
                audioSource.clip = lockedDoorAudio; 
            }
            else //if the door is not locked, or if it's locked and we have the key 
            {
                audioSource.clip = unlockedDoorAudio;
                animator.SetBool("shouldOpen", true);
                displayText = string.Empty;
                isOpen = true;
                isLocked = false;
                UnlockDoor();
            }
            base.InteractWith(); //plays a sound effect              
        }    
    }

    private void UnlockDoor()
    {
        if (storageKey != null && consumeKey)
        {
            PlayerInventory.InventoryObjects.Remove(storageKey);
        }
    }
}
