using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player1;
    public GameObject player2;
    public GameObject mainCamera;

    bool player1Request = false;
    bool player2Request = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        MoveFreeze();
    }

    public void RequestMove(GameObject player)
    {
        if (player == player1)
        {
            player1Request = true;
        }
        else
        {
            player2Request = true;
        }
    }

    internal void MoveFreeze()
    {
        if (player2Request && !player1Request)
        {
            player2.GetComponent<PlayerMovement>().UnFreeze();
            player2.GetComponent<PlayerMovement>().Move();
            player1.GetComponent<PlayerMovement>().Freeze();
        }
        else if (!player2Request && player1Request)
        {
            player1.GetComponent<PlayerMovement>().UnFreeze();
            player1.GetComponent<PlayerMovement>().Move();
            player2.GetComponent<PlayerMovement>().Freeze();
        }
        else if (player1Request && player2Request)
        {
            player1.GetComponent<PlayerMovement>().Freeze();
            player2.GetComponent<PlayerMovement>().Freeze();
        }
        player1Request = false;
        player2Request = false;
    }

    internal void PlayerDie()
    {
        Debug.Log("Glitch To Death");
        StartCoroutine("GlitchToDeath");
    }

    IEnumerator GlitchToDeath()
    {
        GlitchEffects glitch = mainCamera.GetComponent<GlitchEffects>();
        glitch.enabled = true;
        for (float ft = 0f; ft <= 5; ft += 0.1f)
        {
            player1.GetComponent<PlayerMovement>().Freeze();
            player2.GetComponent<PlayerMovement>().Freeze();
            glitch.colorIntensity = ft;
            glitch.flipIntensity = ft;
            yield return new WaitForSeconds(.001f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
