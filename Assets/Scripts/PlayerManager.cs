using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody playerBody;
    public Animator playerAnimator;
    public float speed = 10f;
    public float dodgeSpeed = 20f;
    public float sensitivity = 5f;
    public float jumpforce = 50f;
    public float health;
    public float stamina;
    public bool isGrounded;
    public float horizontalSensitivty = 5;
    public float verticalSensitivty = 5;
    public Transform playerCamera;

    void Update()
    {
        if(true)
        {isGrounded = true;}
    }
}
