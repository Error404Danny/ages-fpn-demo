using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Detects when the Player presses the interact button while looking at an IInteractive,
/// and then calls that IInteractive InteractWith method.
/// </summary>
public class InteractWithLookedAt : MonoBehaviour
{
    private IInteractive lookedAtInteractive;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Interact") && lookedAtInteractive != null)
        {
            Debug.Log("Player pressed the interact button");
            lookedAtInteractive.InteractWith();
        }


    }
    /// <summary>
    /// Event handler for DetectLookedAtInteractive.LookedAtInteractiveChanged.
    /// </summary>
    /// <param name="newLookedAtInteractive">Reference to the new IInteractive the Player is looking at</param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
        
    }

    #region Event Subscrition   / Unsubscrition
    private void OnEnable()
    {
        DetectLookAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookAtInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion
}

