﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{
    public List<GameObject> platforms;
    public Sprite buttonDownSprite;
    public bool initialState = true;
    public float bulletPressTime = 1f;
    Sprite buttonUpSprite;
    // Start is called before the first frame update
    void Start()
    {
        buttonUpSprite = GetComponent<SpriteRenderer>().sprite;
        foreach (GameObject platform in platforms)
        {
            platform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
            foreach (BoxCollider2D collider2D in platform.GetComponents<BoxCollider2D>())
            {
                collider2D.enabled = initialState;
            }
            if (initialState)
            {
                platform.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                platform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Ground" || other.tag == "Bullet")
        {
            GetComponent<AudioSource>().Play();
        }
        if (other.tag == "Bullet")
        {
            GetComponent<SpriteRenderer>().sprite = buttonDownSprite;
            foreach (GameObject platform in platforms)
            {
                if (initialState)
                {
                    platform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
                }
                else
                {
                    platform.GetComponent<SpriteRenderer>().color = Color.white;
                }
                foreach (BoxCollider2D collider2D in platform.GetComponents<BoxCollider2D>())
                {
                    collider2D.enabled = !initialState;
                }
            }
            StartCoroutine("BulletPress");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Ground")
        {
            GetComponent<SpriteRenderer>().sprite = buttonDownSprite;
            foreach (GameObject platform in platforms)
            {
                if (initialState)
                {
                    platform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
                }
                else
                {
                    platform.GetComponent<SpriteRenderer>().color = Color.white;
                }
                foreach (BoxCollider2D collider2D in platform.GetComponents<BoxCollider2D>())
                {
                    collider2D.enabled = !initialState;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().sprite = buttonUpSprite;
        if (other.tag == "Player" || other.tag == "Ground")
        {
            foreach (GameObject platform in platforms)
            {
                if (initialState)
                {
                    platform.GetComponent<SpriteRenderer>().color = Color.white;
                }
                else
                {
                    platform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
                }
                foreach (BoxCollider2D collider2D in platform.GetComponents<BoxCollider2D>())
                {
                    collider2D.enabled = initialState;
                }
            }
        }
    }

    IEnumerator BulletPress()
    {
        yield return new WaitForSeconds(bulletPressTime);
        GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().sprite = buttonUpSprite;
        foreach (GameObject platform in platforms)
        {
            if (initialState)
            {
                platform.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                platform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
            }
            foreach (BoxCollider2D collider2D in platform.GetComponents<BoxCollider2D>())
            {
                collider2D.enabled = initialState;
            }
        }
    }
}
