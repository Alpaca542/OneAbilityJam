using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements.Experimental;

public class Player : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite JumpSprite;

    [Header("Parameters")]
    public float speed = 5f;
    public float jumpForce = 5f;
    private bool isJumping;
    public float health;
    public Gradient healthGradient;

    [Header("Debug")]
    public LayerMask WhatToCheckOnJump;
    private Rigidbody2D rb;
    public Transform rayer1;
    public Transform rayer2;
    public Transform rayer3;
    public Animator myAnimator;
    public string ActiveAbility;
    public Slider healthBar;
    public bool healing;
    public float AllTheDamage;
    public Image fill;
    public GameObject gun;
    public bool CantDie = false;
    public Volume volume;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 30f;
    private float dashingTime = 0.7f;
    private float dashingCooldown = 1f;
    private TrailRenderer tr;

    private float coyoteeTime = 0.2f;
    private float coyoteeTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    public Color[] vignettereffects;

    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(float dmg)
    {
        if(!CantDie)
        {
            health -= dmg;
            AllTheDamage += dmg;
            if (health <= 0)
            {
                Die();
            }
            if (!healing)
            {
                StartCoroutine(CrtnTakeDamage());
            }
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public void GetAbility(string which)
    {
        speed = 6;
        CantDie = false;
        canDash = false;
        fill.color = healthGradient.Evaluate(healthBar.normalizedValue);
        gun.SetActive(false);
        if (which == "Health")
        {
            Vignette vgn;
            if (volume.profile.TryGet<Vignette>(out vgn))
            {
                vgn.active = true;
                vgn.color.value = vignettereffects[0];
            }
            CantDie = true;
            health = 100f;
            healthBar.value = health;
            fill.color = new Color32(0, 0, 255, 255);
        }
        if (which == "Machine gun")
        {
            Vignette vgn;
            if (volume.profile.TryGet<Vignette>(out vgn))
            {
                vgn.active = true;
                vgn.color.value = vignettereffects[1];
            }
            gun.SetActive(true);
            gun.GetComponent<GunScript>().firerate = 0.1f;
            gun.GetComponent<GunScript>().Shotgun = false;
            gun.GetComponent<GunScript>().activeBullet = gun.GetComponent<GunScript>().blts[0];
        }
        if (which == "Shotgun")
        {
            Vignette vgn;
            if (volume.profile.TryGet<Vignette>(out vgn))
            {
                vgn.active = true;
                vgn.color.value = vignettereffects[2];
            }
            gun.SetActive(true);
            gun.GetComponent<GunScript>().firerate = 0.5f;
            gun.GetComponent<GunScript>().Shotgun = true;
            gun.GetComponent<GunScript>().activeBullet = gun.GetComponent<GunScript>().blts[1];
        }
        if (which == "Speedboost")
        {
            Vignette vgn;
            if (volume.profile.TryGet<Vignette>(out vgn))
            {
                vgn.active = true;
                vgn.color.value = vignettereffects[3];
            }
            speed = 10f;
        }
        if (which == "Dash")
        {
            Vignette vgn;
            if (volume.profile.TryGet<Vignette>(out vgn))
            {
                vgn.active = true;
                vgn.color.value = vignettereffects[4];
            }
            canDash = true;
        }
    }
    public IEnumerator CrtnTakeDamage()
    {
        healing = true;
        while (AllTheDamage >= 0.4f)
        {
            if (CantDie)
            {
                break;
            }
            healthBar.value -= 0.2f;
            AllTheDamage -= 0.2f;
            fill.color = healthGradient.Evaluate(healthBar.normalizedValue);
            yield return new WaitForSeconds(0.01f);
        }
        healing = false;
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

        if (isDashing)
        {
            return;
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

        if (IsGrounded())
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isDashing)
        {
            collision.GetComponent<CircleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<EnemyScript>().Die();
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = rb.velocity.normalized * dashingPower;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}