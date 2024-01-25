using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerManager playerManager;
    private PlayerInputController playerInputController;
    private Vector3 moveDirection;
    private Vector3 movementVelocity;
    private float xRotation;
    private float yRotation;
    private float timeOffset;
    private void Update()
    {
        if (timeOffset < playerManager.dodgeCooldown)
        {
            timeOffset += Time.deltaTime;
        }
    }
    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        playerInputController= GetComponent<PlayerInputController>();
    }
    public void OnMove(float horizontal, float vertical)
    {
        moveDirection = new Vector3(horizontal, 0f, vertical) ;
        //Clamp to set max speed

        movementVelocity = transform.TransformDirection(moveDirection) * playerManager.speed;
        playerManager.playerBody.velocity = movementVelocity;
    }
    public void OnRotation(float mouseX, float mouseY)
    {
        yRotation += mouseX * playerManager.verticalSensitivity;
        xRotation -= mouseY * playerManager.horizontalSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(0f, yRotation, 0f);
        playerManager.playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        yRotation = 0;
    }
    public void OnJump()
    {
        if  (playerManager.isGrounded)
        {
            // Currently floats really slowly down
            playerManager.playerBody.AddForce(moveDirection.x, playerManager.jumpforce, moveDirection.z, ForceMode.Impulse);
        }
    }
    public void OnDodge()
    {
        if ((timeOffset >= playerManager.dodgeCooldown) && (playerManager.isGrounded))
        {
            playerManager.playerBody.AddForce(moveDirection.x, playerManager.dodgeSpeed, moveDirection.z, ForceMode.Impulse);
            timeOffset = 0;
        }
    }
    public void OnInteract()
    {

    }
    public void OnAttack()
    {

    }
    public void OnAim()
    {

    }
    public void OnPause()
    {

    }
    public void OnResume()
    {

    }
    public void OnDamage()
    { 
    
    }
}
