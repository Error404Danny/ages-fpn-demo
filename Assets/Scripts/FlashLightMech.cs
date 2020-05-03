using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightMech : MonoBehaviour
{
    private bool flashlightEnabled;
    public GameObject flashlight;
    public GameObject lightOBJ;
    public float maxEnergy;
    private float currentEnergy;
    private int batteries;
    public GameObject batteryObject;
    private float usedEnergy;

    public void Start()
    {
        currentEnergy = maxEnergy;
        maxEnergy = 50 * batteries;
    }

    public void FixedUpdate()
    {
        maxEnergy = 50 * batteries;
        currentEnergy = maxEnergy;
        //equip
        if (Input.GetKeyDown(KeyCode.F))
            flashlightEnabled = !flashlightEnabled;
       if (flashlightEnabled)
        {
            flashlight.SetActive(true);

            if (currentEnergy <= 0)
            {
                lightOBJ.SetActive(false);
                batteries = 0;
            }
            if (currentEnergy > 0)
            {
                lightOBJ.SetActive(true);
                currentEnergy -= 0.5f * Time.deltaTime;
                usedEnergy += 0.1f * Time.deltaTime;
            }
            if (usedEnergy >= 50)
            {
                batteries -= 1;
                usedEnergy = 0;
            }
        }
       else
        {
            flashlight.SetActive(false);
        }
        print("Batteries: " + batteries);
        print("usedEnergy: " + usedEnergy);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Battery")
        {
            batteryObject = other.gameObject;
            batteries += 1;
            Destroy(batteryObject);
        }
    }
}
