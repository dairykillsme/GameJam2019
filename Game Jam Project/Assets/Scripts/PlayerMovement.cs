using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    bool isTouchingFloor;
    public int topSpeed = 10;
    public int drag = 10;
    public int jumpForce = 250;
    public int moveForce = 100;
    public KeyCode leftKey = KeyCode.None;
    public KeyCode rightKey = KeyCode.None;
    public KeyCode jumpKey = KeyCode.None;

    public Vector2 preFreezeVelocity;
    bool frozen = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey) || Input.GetKey(rightKey) || Input.GetKey(leftKey))
        {
            GameManager.instance.RequestMove(this.gameObject);
            //Move();
        }

        if (isTouchingFloor)
        {
            if (rb2d.velocity.x > 0)
            {
                rb2d.AddForce(Vector2.left * drag);
            }
            else if (rb2d.velocity.x < 0)
            {
                rb2d.AddForce(Vector2.right * drag);
            }
        }
    }

    internal void Move()
    {
        
        if (isTouchingFloor)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                rb2d.AddForce(Vector2.up * jumpForce);
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
            frozen = true;
            preFreezeVelocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
            rb2d.bodyType = RigidbodyType2D.Static;
        }
    }

    internal void UnFreeze()
    {
        if (frozen)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            rb2d.velocity = preFreezeVelocity;
            frozen = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag  == "Ground" || collision.tag == "Player")
        {
            isTouchingFloor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Player")
        {
            isTouchingFloor = false;
        }
    }
}
