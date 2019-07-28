using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    bool gravitySwitch = false;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

/*        if (Input.GetButtonDown("GravitySwitch"))
        {
            if (rb.gravityScale >= 0)
            {
                rb.gravityScale = -2;
            }
            else if (rb.gravityScale <= 0)
            {
                rb.gravityScale = 2;
            }
            controller.FlipGravity();
            gravitySwitch = true;
        }
        */
    }

    void FixedUpdate() {

        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, gravitySwitch);
        jump = false;
    }
}
