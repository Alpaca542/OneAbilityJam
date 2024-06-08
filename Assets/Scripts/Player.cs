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
    public bool AmIFlying = false;
    private Rigidbody2D rb;
    public Transform rayer1;
    public Transform rayer2;
    public Transform rayer3;
    public Animator myAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        AmIFlying = false;
        myAnimator.SetBool("walkAnimation", false);
        //GetComponent<SpriteRenderer>().sprite = JumpSprite;
    }
    void Update()
    {

        if (!AmIFlying)
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

            if (Input.GetKeyDown(KeyCode.Space) && (Physics2D.Raycast(rayer1.position, Vector2.down, 0.001f, WhatToCheckOnJump) || Physics2D.Raycast(rayer2.position, Vector2.down, 0.001f, WhatToCheckOnJump) || Physics2D.Raycast(rayer3.position, Vector2.down, 0.001f, WhatToCheckOnJump)))
            {
                rb.AddForce(Vector2.up * jumpForce);
            }
            myAnimator.SetBool("walkAnimation", true);
        }
    }
}