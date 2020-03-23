﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);

    public virtual string DisplayText => displayText;
    protected AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();

        }
        catch (System.Exception )
        {

            throw new System.Exception("Missing Audio Component-Interactive Object requires an AudioSource Component to be good. Check if AudioClip is in the object");
        }
        Debug.Log($"Player just interacted with : {gameObject.name}.");
    }
}
