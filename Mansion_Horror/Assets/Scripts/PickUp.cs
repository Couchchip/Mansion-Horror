using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider boxColl;
    [SerializeField] private Transform player;
    [SerializeField] private Transform container;
    [SerializeField] private Transform cam;
    [SerializeField] private float pickUpRange;
    [SerializeField] private float dropForwardForce;
    [SerializeField] private float dropUpwardForce;
    [SerializeField] private bool equipped;
    [SerializeField] private bool slotFull;

    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    void PickUpObject()
    {

    }
    void DropObject()
    {

    }
}
