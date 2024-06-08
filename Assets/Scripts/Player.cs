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
    private bool isJumping;

    [Header("Debug")]
    public LayerMask WhatToCheckOnJump;
    private Rigidbody2D rb;
    public Transform rayer1;
    public Transform rayer2;
    public Transform rayer3;
    public Animator myAnimator;
    public string ActiveAbility;

    private float coyoteeTime = 0.2f;
    private float coyoteeTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }


        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0)
        {
            if (moveHorizontal > 0.2 && transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (moveHorizontal < -0.2 && transform.rotation != Quaternion.Euler(0, -180, 0) && transform.rotation != Quaternion.Euler(0, 180, 0))
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

        if(IsGrounded())
        {
            coyoteeTimeCounter = coyoteeTime;
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
            coyoteeTimeCounter -= Time.deltaTime;
            myAnimator.SetBool("Walking", false);
            myAnimator.SetBool("Jumping", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            coyoteeTimeCounter = 0f;
        }
        if (jumpBufferCounter > 0f && coyoteeTimeCounter > 0f && !isJumping)
        {
            jumpBufferCounter = 0f;
            rb.AddForce(Vector2.up * jumpForce);
            StartCoroutine(JumpCooldown());
        }
    }
    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
    public bool IsGrounded()
    {
        return Physics2D.Raycast(rayer1.position, Vector2.down, 0.01f, WhatToCheckOnJump) || Physics2D.Raycast(rayer2.position, Vector2.down, 0.01f, WhatToCheckOnJump) || Physics2D.Raycast(rayer3.position, Vector2.down, 0.01f, WhatToCheckOnJump);
    }
}