using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Time;

public class PlayerInputController : MonoBehaviour
{
    public PlayerManager _playerManager;
    public PlayerController _playerController;
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
        _playerController.OnMove(horizontalInput, verticalInput);
        //Rotation
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _playerManager.horizontalSensitivty;
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _playerManager.verticalSensitivty;
        _playerController.OnRotation(mouseX, mouseY);
        //Dodge
        if (Input.GetKey(KeyCode.R) && (_playerManager.isGrounded))
        { _playerController.OnDodge();}
        //Jump
        if (Input.GetKey(KeyCode.Space) && (_playerManager.isGrounded))
        { _playerController.OnJump();}
        //Interact
        if (Input.GetKey(KeyCode.F))
        { _playerController.OnInteract();}
        //Attack
        if (Input.GetMouseButtonDown(0))
        { _playerController.OnAttack();}
        //Aim
        if (Input.GetMouseButtonDown(1))
        { _playerController.OnAim();}
    }

}
