using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public PlayerManager playerManager;
    public PlayerController playerController;
    public float horizontalInput;
    public float verticalInput;
    public float mouseX;
    public float mouseY;
    // Update is called once per frame
    void Update()
    {
        //takes Input for Horizontal and Vertical inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        //Move
        playerController.OnMove(horizontalInput, verticalInput);
        //Rotation
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * playerManager.horizontalSensitivty;
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * playerManager.verticalSensitivty;
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
