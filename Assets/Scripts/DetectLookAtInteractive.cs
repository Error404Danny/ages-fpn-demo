﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects Object the player is Looking at 
/// </summary>
public class DetectLookAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactibles.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("How far from raycastOrigin we will search for interactive elements.")]
    [SerializeField]
    private float maxRange = 5.0f;

    public IInteractive LookedAtInteractive
    {
        get { return lookedAtInteractive;}
        private set { lookedAtInteractive = value; } 
    }
    private IInteractive lookedAtInteractive;

    private void FixedUpdate()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);
        RaycastHit hitInfo;
        bool ObjectWasDetected =  Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);

        IInteractive interactive = null;

        LookedAtInteractive = interactive;
        if (ObjectWasDetected)
        {
            //Debug.Log($"Player is looking at : {hitInfo.collider.gameObject.name}");
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }
        if (interactive != null)
            lookedAtInteractive = interactive; 
    }
}