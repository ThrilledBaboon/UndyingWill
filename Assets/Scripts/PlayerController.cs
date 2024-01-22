using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerManager playerManager;
    public PlayerInputController playerInputController;
    public Vector3 moveDirection;
    public Vector3 movementVelocity;
    public float xRotation;
    public float yRotation;
    public void OnMove(float horizontal, float vertical)
    {
        moveDirection = new Vector3(horizontal, 0f, vertical) ;
        //Clamp to set max speed
        movementVelocity = moveDirection * playerManager.speed;
        playerManager.playerBody.velocity = movementVelocity;
    }
    public void OnRotation(float mouseX, float mouseY)
    {
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(0f, yRotation * playerManager.sensitivity, 0f);
        playerManager.playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
    public void OnJump()
    {
        // Currently floats really slowly down
        playerManager.playerBody.AddForce(moveDirection.x, playerManager.jumpforce, moveDirection.z, ForceMode.Impulse);
    }
    public void OnDodge()
    {
        // will need a cooldown
        movementVelocity = movementVelocity * playerManager.dodgeSpeed;
        playerManager.playerBody.AddForce(movementVelocity.x, movementVelocity.y, movementVelocity.z, ForceMode.Impulse);
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
