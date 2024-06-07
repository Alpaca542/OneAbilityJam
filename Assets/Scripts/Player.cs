using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    public Sprite[] sprites;
    private bool inTheAir = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !inTheAir)
        {
            rb.AddForce(Vector2.up * jumpForce);
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            inTheAir = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            inTheAir = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
    }
}
