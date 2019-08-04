using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 1;
    public Vector2 direction = Vector2.left;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = speed * direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!other.GetComponent<PlayerMovement>().frozen)
            {
                GameManager.instance.PlayerDie();
            }
        }
        Destroy(this.gameObject);
    }
}
