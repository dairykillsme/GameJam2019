using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{
    public GameObject platform;
    public Sprite buttonDownSprite;
    Sprite buttonUpSprite;
    // Start is called before the first frame update
    void Start()
    {
        platform.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 0.3f);
        foreach (BoxCollider2D collider2D in platform.GetComponents<BoxCollider2D>())
        {
            collider2D.enabled = false;
        }
        buttonUpSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Ground")
        {
            GetComponent<SpriteRenderer>().sprite = buttonDownSprite;
            platform.GetComponent<SpriteRenderer>().color = Color.white;
            foreach (BoxCollider2D collider2D in platform.GetComponents<BoxCollider2D>())
            {
                collider2D.enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Ground")
        {
            GetComponent<SpriteRenderer>().sprite = buttonUpSprite;
            platform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
            foreach (BoxCollider2D collider2D in platform.GetComponents<BoxCollider2D>())
            {
                collider2D.enabled = false;
            }
        }
    }
}
