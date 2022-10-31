using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    public bool drinkIsFull;
    [SerializeField] private GameObject drinkItself;
    public float increaseStaminaTo = 15f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            drinkIsFull = false;
        }
        if(drinkIsFull)
        {
            Destroy(drinkItself);
        }
    }
}
