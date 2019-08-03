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
            Debug.Log("Gamers?");
            rb2d.AddForce(Vector2.left * moveForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag  == "Ground")
        {
            isTouchingFloor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isTouchingFloor = false;
        }
    }
}
