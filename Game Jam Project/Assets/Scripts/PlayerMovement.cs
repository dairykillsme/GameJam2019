using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public bool isTouchingFloor = true;
    public int topSpeed = 10;
    public int drag = 30;
    public int jumpForce = 250;
    public int moveForce = 100;
    public KeyCode leftKey = KeyCode.None;
    public KeyCode rightKey = KeyCode.None;
    public KeyCode jumpKey = KeyCode.None;

    public Vector2 preFreezeVelocity;
    bool frozen = false;
    bool wasFrozen = false;
    float localScale;
    Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        localScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(jumpKey) || Input.GetKey(rightKey) || Input.GetKey(leftKey))
        {
            GameManager.instance.RequestMove(this.gameObject);
            //Move();
        }

        if (isTouchingFloor)
        {
            if (rb2d.velocity.x > -1 && rb2d.velocity.x < 1)
            {
                rb2d.velocity = Vector2.zero;
            }
            else if (rb2d.velocity.x > 1)
            {
                rb2d.AddForce(Vector2.left * drag);
            }
            else if (rb2d.velocity.x < -1)
            {
                rb2d.AddForce(Vector2.right * drag);
            }
        }

        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        if (rb2d.velocity.x > 0)
        {
            Vector2 flipX = new Vector2(localScale, transform.localScale.y);
            transform.localScale = flipX;
            playerAnim.SetTrigger("moving");
        }
        else if (rb2d.velocity.x < 0)
        {
            Vector2 flipX = new Vector2(-localScale, transform.localScale.y);
            transform.localScale = flipX;
            playerAnim.SetTrigger("moving");
        }
        else
        {
            playerAnim.SetTrigger("idle");
        }
    }

    internal void Move()
    {
        if (isTouchingFloor)
        {
            if (Input.GetKey(jumpKey))
            {
                if (rb2d.velocity.y <= 0)
                {
                    rb2d.velocity += Vector2.up * jumpForce;
                    isTouchingFloor = false;
                }
            }
        }

        if (Input.GetKey(rightKey) && rb2d.velocity.x < topSpeed)
        {
            rb2d.AddForce(Vector2.right * moveForce);
        }

        if (Input.GetKey(leftKey) && rb2d.velocity.x > -topSpeed)
        {
            rb2d.AddForce(Vector2.left * moveForce);
        }
    }

    internal void Freeze()
    {
        if (!frozen)
        {
            playerAnim.SetBool("glitching", true);
            frozen = true;
            preFreezeVelocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
            rb2d.bodyType = RigidbodyType2D.Static;
        }
    }

    internal void UnFreeze()
    {
        if (frozen)
        {
            playerAnim.SetBool("glitching", false);
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            rb2d.velocity = preFreezeVelocity;
            frozen = false;
            if (isTouchingFloor)
            {
                wasFrozen = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            isTouchingFloor = true;
        }
    }
}
