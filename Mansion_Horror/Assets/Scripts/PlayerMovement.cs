using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField] private float groundDistance = .4f;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float maxStamina;
    [SerializeField] private float currentStamina;
    [SerializeField] private float minStaminaToSprint;
    [SerializeField] private float slowWalkSpeed;

    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isSprinting = false;
    [SerializeField] private bool canSprint;
    [SerializeField] private bool isSlowWalking = false;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
        currentStamina = maxStamina;
        //canSprint = true;
    }

    // Update is called once per frame
    void Update()
    {
        Basics();
        SprintingAndWalking();
    }

    void Basics()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight) * -2 * gravity;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void SprintingAndWalking()
    {
        //holding shift = sprint
        if(Input.GetKey(KeyCode.LeftShift) && currentStamina > 0 && canSprint)
        {
            isSprinting = true;
            isSlowWalking = false;
            //stamina drain
            currentStamina = currentStamina - 1 * Time.deltaTime;
        }
        else
        {
            //stamina gain logic
            isSprinting = false;
            if(currentStamina < 1)
            {
                canSprint = false;
            }
            if(currentStamina > minStaminaToSprint)
            {
                canSprint = true;
            }
            if(currentStamina < maxStamina)
            {
                currentStamina = currentStamina + 1 * Time.deltaTime;
            }
        }

        //if is sprinting or slow walking, set speed
        if (isSprinting)
        { speed = sprintSpeed; }
        else if (isSlowWalking)
        { speed = slowWalkSpeed; }
        else
            speed = walkSpeed;



        if(!isSprinting)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                isSprinting = false;
                isSlowWalking = true;
            }
            else
                isSlowWalking=false;


        }
              
    }


}
