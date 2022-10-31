using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Flashlight flashlightScript;
    public EnergyDrink energyDrinkScript;
    public Rigidbody rb;
    public BoxCollider boxColl;
    public Transform player;
    public Transform container;
    public Transform cam;
    public float pickUpRange;
    public float dropForwardForce;
    public float dropUpwardForce;
    public bool equipped;
    public bool slotFull;

    private void Start()
    {
        if(!equipped)
        {
            flashlightScript.enabled = false;
            rb.isKinematic = false;
            boxColl.isTrigger = false;
        }
        if (equipped)
        {
            flashlightScript.enabled = true;
            rb.isKinematic = true;
            boxColl.isTrigger = true;
            slotFull = true;
        }
    }

    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.F) && !slotFull)
        {
            PickUpObject();
        }
        else if(equipped && slotFull && Input.GetKeyDown(KeyCode.G))
        {
            DropObject();
        }
    }

    void PickUpObject()
    {
        equipped = true;
        slotFull = true;

        rb.isKinematic = true;
        boxColl.isTrigger = true;
        flashlightScript.enabled = true;

        transform.SetParent(container);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

    }
    void DropObject()
    {
        equipped = false;
        slotFull = false;

        rb.isKinematic = false;
        boxColl.isTrigger = false;
        flashlightScript.enabled = false;

        transform.SetParent(null);

        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(cam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(cam.up * dropUpwardForce, ForceMode.Impulse);
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
    }
}
