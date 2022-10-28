using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject light1;

    [SerializeField] private bool isOn = false;
    //if character isn't holding, change to false
    public bool characterIsHolding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnOff();
    }

    void OnOff()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isOn)
        {
            isOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.T) && isOn)
        {
            isOn = false;
        }

        if (isOn)
        {
            light1.SetActive(true);
        }
        if (!isOn)
        {
            light1.SetActive(false);
        }
    }
}
