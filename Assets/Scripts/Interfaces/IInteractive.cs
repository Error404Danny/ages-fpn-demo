﻿/// <summary>
/// Interface for elements the player can interact with by pressing the Interact Button
/// </summary>
public interface IInteractive 
{
    string DisplayText { get; }
    void InteractWith();
}
