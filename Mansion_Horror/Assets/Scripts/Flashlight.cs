using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject light1;

    [SerializeField] private float maxBattery;
    [SerializeField] private float currentBattery;

    [SerializeField] private bool canTurnOn;
    [SerializeField] private bool isOn = false;
    //if character isn't holding, change to false
    public bool characterIsHolding;

    // Start is called before the first frame update
    void Start()
    {
        maxBattery = 10;
        currentBattery = maxBattery;
        canTurnOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        OnOff();

        if (Input.GetKey(KeyCode.R) && currentBattery < maxBattery && !isOn)
        {
            currentBattery = currentBattery + .5f * Time.deltaTime;
        }

    }

    void OnOff()
    {
        //t to turn on/off with logic
        if (Input.GetKeyDown(KeyCode.T) && !isOn && canTurnOn)
        {
            isOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.T) && isOn)
        {
            isOn = false;
        }

        //on off
        if (isOn)
        { light1.SetActive(true); currentBattery = currentBattery - 1 * Time.deltaTime; }
        if (!isOn)
        { light1.SetActive(false); }

        //no battery means no work
        if (currentBattery <= 0)
        {
            isOn = false;
            canTurnOn = false;
        }
        else if(currentBattery >0)
        {
            canTurnOn = true;
        }

    }

   

}
