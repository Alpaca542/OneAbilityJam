using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite JumpSprite;

    [Header("Parameters")]
    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("Debug")]
    public LayerMask WhatToCheckOnJump;
    private Rigidbody2D rb;
    public Transform rayer1;
    public Transform rayer2;
    public Transform rayer3;
    public Animator myAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0)
        {
            if (moveHorizontal > 0.2 && transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (moveHorizontal < -0.2 && transform.rotation != Quaternion.Euler(0, -180, 0) && transform.rotation != Quaternion.Euler(0, 180, 0))
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

        if(Physics2D.Raycast(rayer1.position, Vector2.down, 0.001f, WhatToCheckOnJump) || Physics2D.Raycast(rayer2.position, Vector2.down, 0.001f, WhatToCheckOnJump) || Physics2D.Raycast(rayer3.position, Vector2.down, 0.001f, WhatToCheckOnJump))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpForce);
            }
            if (rb.velocity == Vector2.zero)
            {
                myAnimator.SetBool("Walking", false);
                myAnimator.SetBool("Jumping", false);
            }
            else
            {
                myAnimator.SetBool("Walking", true);
                myAnimator.SetBool("Jumping", false);
            }
        }
        else
        {
            myAnimator.SetBool("Walking", false);
            myAnimator.SetBool("Jumping", true);
        }
    }
}