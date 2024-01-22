using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform feet;
    public Rigidbody playerBody;
    public Animator playerAnimator;
    public LayerMask floor;
    public float speed = 10f;
    public float dodgeSpeed = 20f;
    public float sensitivity = 5f;
    public float jumpforce = 50f;
    public float health;
    public float stamina;
    public bool isGrounded;
    public float horizontalSensitivity = 5f;
    public float verticalSensitivity = 5f;
    public Transform playerCamera;
    public float dodgeCooldown = 1.5f;

    void Update()
    {
        if(Physics.CheckSphere(feet.position, 0.1f, floor)){isGrounded = true;}
        else{isGrounded = false;}
    }
}
