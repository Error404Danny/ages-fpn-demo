using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuItemTogglePrefab;

    [Tooltip("The Content of the scrollview for the list of inventory items.")]
    [SerializeField]
    private Transform inventoryListContentArea;

    [Tooltip("Place in the UI for displaying the name of the selected inventory Item")]
    [SerializeField]
    private Text itemLabelText;

    [Tooltip("Place in the UI for displaying the info about the selected inventroy Item")]
    [SerializeField]
    private Text descriptionAreaText;

    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    private InteractWithLookedAt interactWithLookedAt;
    private AudioSource audioSource;


    public static InventoryMenu Instance
    {
        
        get
        {
            if (instance == null)
                throw new System.Exception("There is currently no InventroyMenu instnace, "
                    + "but you are trying to access it. Make sure the InventroyMenu script is applied to a GameObject in the scene");
            return instance;
        }
        private set { instance = value; }
    }

    private bool isVisible => canvasGroup.alpha > 0;

    public void ExitMenuButtonClicked()
    {
        HideMenu();
    }

    /// <summary>
    /// Instantiates a new InventoryMenuItemToggle prefab and adds it to the menu.
    /// </summary>
    /// <param name="inventoryObjectToAdd"></param>
    public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
    {
       GameObject clone = Instantiate(inventoryMenuItemTogglePrefab, inventoryListContentArea);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;
        
    }

    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        rigidbodyFirstPersonController.enabled = false;
        interactWithLookedAt.enabled = false; 
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        audioSource.Play();
    }
    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rigidbodyFirstPersonController.enabled = true;
        interactWithLookedAt.enabled = true;
        audioSource.Play();
    }

    private void OnInventoryMenuItemSelected(InventoryObject inventoryObjectThatWasSelected)
    {
        itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
        descriptionAreaText.text = inventoryObjectThatWasSelected.Description;
    }

    /// <summary>
    /// This is the event Handler for InventoryMenuItemSelected.
    /// </summary>
    private void OnEnable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected += OnInventoryMenuItemSelected;
    }

    private void OnDisable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected -= OnInventoryMenuItemSelected;
    }
    private void Update()
    {
        HandleInput();
    }
    private void HandleInput()
    {
        if (Input.GetButtonDown("Show Inventory Menu"))
            if (isVisible)
                HideMenu();
            else
                ShowMenu();
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("There is already an instnace of InventoryMenu and there can only be one");

        canvasGroup = GetComponent<CanvasGroup>();
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        interactWithLookedAt = FindObjectOfType<InteractWithLookedAt>();
        audioSource = GetComponent<AudioSource>();
     
    }
    private void Start()
    {    
        HideMenu();
        StartCoroutine(WaitForAudioClip());
    }

    private IEnumerator WaitForAudioClip()
    {
        float originalAudioVolume = audioSource.volume;
        audioSource.volume = 0;
        Debug.Log("Start Waiting");
        yield return new WaitForSeconds(2);
        Debug.Log("Stop Waiting");
        audioSource.volume = originalAudioVolume;
    }
}
