using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    private Animator animator;

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
 
        
            base.InteractWith();
            animator.SetBool("shouldOpen", true);
            
    
        

    }
}
