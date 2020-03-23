using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [Tooltip("The name that will display in the game world when the player looks at it")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    //TODO: ADD LONG DESCRIPTION FIELD
    //TODO: ADD ICON FIELD 

    private new Renderer renderer;
    private new Collider collider;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }
    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }
    /// <summary>
    /// When the player interacts with an inventory Object, we need to do 2 things:
    /// 1.Add the inventory objects to the PlayerInventory List 
    /// 2. Remove the object from the game world/ Scene
    /// Cannot Destory because I need to keep gameobject in inventory list
    /// So disabling the collider and renderer is best option for now
    /// </summary>
    public override void InteractWith()
    {
       base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        renderer.enabled = false;
        collider.enabled = false; 
        
    }
}
