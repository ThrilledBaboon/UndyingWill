using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;

    [SerializeField] private LayerMask FloorMask;
    [SerializeField] private Transform FeetTransform;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float RollSpeed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float Jumpforce;

    // Update is called once per frame
    void Update()
    {
        // records input for main input key
        // A = -1 D = 1, W = 1 S = -1
        //GetAxis has smoothing when compared to GetAxisRaw
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer()
    {
        //This line has a faster speed on a diagonal than a straight.
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);

        //check if space is pressed.
        if (Input.GetKeyDown(KeyCode.R))
        {
            //check if on ground
            if (Physics.CheckSphere(FeetTransform.position, 1f, FloorMask))
            {
                MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed * RollSpeed;
                PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);
            }

        }
    }

    private void MovePlayerCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
}
