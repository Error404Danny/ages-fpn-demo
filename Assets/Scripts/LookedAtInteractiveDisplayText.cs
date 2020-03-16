using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This UI text displays info about the currently looked at interactive element. 
/// The text should be hidden if the player is not looking at an interactive.
/// </summary>
public class LookedAtInteractiveDisplayText : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    private Text displayText;

    private void Awake()
    {
        displayText = GetComponent<Text>();
        UpdateDisplayText(); 
    }
    private void UpdateDisplayText()
    {
        if (lookedAtInteractive != null)
            displayText.text = lookedAtInteractive.DisplayText;
        else
            displayText.text = string.Empty;
    }
    /// <summary>
    /// Event handler for DetectLookedAtInteractive.LookedAtInteractiveChanged.
    /// </summary>
    /// <param name="newLookedAtInteractive">Reference to the new IInteractive the Player is looking at</param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
        UpdateDisplayText();
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
