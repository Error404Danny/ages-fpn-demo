using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Check this box to lock the door")]
    [SerializeField]
    private bool isLocked;

    [Tooltip("Text when Player looks at Locked Doors")]
    [SerializeField]
    private string lockedDoorText = "Locked";

    [Tooltip("Audio plays when Player interacts with Locked Door")]
    [SerializeField]
    private AudioClip lockedDoorAudio;

    [Tooltip("Audio plays when Player interacts with an unlocked Door")]
    [SerializeField]
    private AudioClip unlockedDoorAudio;

    public override string DisplayText => isLocked ? lockedDoorText : base.DisplayText; 

    private Animator animator;
    private bool isOpen = false;
    
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
    }

    public override void InteractWith()
    {
 
        if (!isOpen)
        {
            if (!isLocked)
            {
                audioSource.clip = unlockedDoorAudio;
                animator.SetBool("shouldOpen", true);
                displayText = string.Empty;
                isOpen = true;
            }
            else //Door is Locked
            {
                audioSource.clip = lockedDoorAudio; 
            }
           base.InteractWith(); //plays a sound effect
               
        }

        

    }
}
