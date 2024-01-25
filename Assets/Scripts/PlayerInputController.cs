using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerManager playerManager;
    private PlayerController playerController;
    private float horizontalInput;
    private float verticalInput;
    private float mouseX;
    private float mouseY;
    // Update is called once per frame
    private void Start()
    {
        playerController= GetComponent<PlayerController>();
        playerManager= GetComponent<PlayerManager>();
    }
    void Update()
    {
        //takes Input for Horizontal and Vertical inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        //Move
        playerController.OnMove(horizontalInput, verticalInput);
        //Rotation
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        playerController.OnRotation(mouseX, mouseY);
        //Dodge
        if (Input.GetKey(KeyCode.R) && (playerManager.isGrounded))
        { playerController.OnDodge();}
        //Jump
        if (Input.GetKey(KeyCode.Space) && (playerManager.isGrounded))
        { playerController.OnJump();}
        //Interact
        if (Input.GetKey(KeyCode.F))
        { playerController.OnInteract();}
        //Attack
        if (Input.GetMouseButtonDown(0))
        { playerController.OnAttack();}
        //Aim
        if (Input.GetMouseButtonDown(1))
        { playerController.OnAim();}
    }

}
