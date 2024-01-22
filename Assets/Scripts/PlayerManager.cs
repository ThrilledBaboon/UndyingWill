using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody PlayerBody;
    public Animator PlayerAnimator;
    public float Speed = 10f;
    public float DodgeSpeed = 20f;
    public float Sensitivity = 5f;
    public float Jumpforce = 50f;
    public float Health;
    public float Stamina;
    public bool isGrounded;
    public float horizontalSensitivty = 5;
    public float verticalSensitivty = 5;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBody = GetComponent<Rigidbody>();
        PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if(true)
        {isGrounded = true;}
    }
}
