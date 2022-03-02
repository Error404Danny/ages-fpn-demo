using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTalk : MonoBehaviour
{
    private GameObject triggeringNPC;
    private bool triggering;
    public GameObject npcText;

    void Update()
    {
        if (triggering)
        {
            npcText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("It works");
            }
        }
        else
        {
            npcText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Radio")
        {
            triggering = true;
            triggeringNPC = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Radio")
        {
            triggering = false;
            triggeringNPC = null;
        }
    }
}
