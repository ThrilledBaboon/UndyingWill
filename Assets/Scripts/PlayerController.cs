using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerManager _playerManager;
    public PlayerInputController _playerInputController;
    public Vector3 moveDirection;
    public Transform cameraObject;
    public Vector3 movementVelocity;
    public float xRotation;
    public float yRotation;
    public void OnMove(float horizontal, float vertical)
    {
        moveDirection = new Vector3(horizontal, 0f, vertical) ;
        //Clamp to set max speed
        movementVelocity = moveDirection * _playerManager.Speed;
        _playerManager.PlayerBody.velocity = movementVelocity;
    }
    public void OnRotation(float mouseX, float mouseY)
    {
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
    public void OnJump()
    {
        // Currently floats really slowly down
        _playerManager.PlayerBody.AddForce(moveDirection.x, _playerManager.Jumpforce, moveDirection.z, ForceMode.Impulse);
    }
    public void OnDodge()
    {
        // will need a cooldown
        movementVelocity = movementVelocity * _playerManager.DodgeSpeed;
        _playerManager.PlayerBody.AddForce(movementVelocity.x, movementVelocity.y, movementVelocity.z, ForceMode.Impulse);
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
}
