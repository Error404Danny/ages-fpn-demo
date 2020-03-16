using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetSwitch : InteractiveObject
{
    [Tooltip("The GameObject to Toggle.")]
    [SerializeField]
    private GameObject objectToToggle;

    [Tooltip("Can the player interact with this object more than Once?")]
    [SerializeField]
    private bool isReuseable = true;

    private bool hasBeenUsed = false;
    /// <summary>
    /// Toggle the activeSelf value for the objectToToggle when the player interacts with this item
    /// </summary>
    public override void InteractWith()
    {
        if (isReuseable || !hasBeenUsed)
        {
            base.InteractWith();
            objectToToggle.SetActive(!objectToToggle.activeSelf);
            hasBeenUsed = true;
            if (!isReuseable)
            {
                displayText = string.Empty;
            }
        }
    }
}
