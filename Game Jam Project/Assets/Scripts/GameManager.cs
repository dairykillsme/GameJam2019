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
    bool player1Finish = false;
    bool player2Finish = false;

    float glitchiness = 0;
    GlitchEffects glitch;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        glitch = mainCamera.GetComponent<GlitchEffects>();
    }

    // Update is called once per frame
    void Update()
    {
        if (glitchiness < 1)
        {
            glitch.flipIntensity = glitchiness;
            glitch.intensity = glitchiness;
        }
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
            glitchiness = 0;
            player2.GetComponent<PlayerMovement>().UnFreeze();
            player2.GetComponent<PlayerMovement>().Move();
            player1.GetComponent<PlayerMovement>().Freeze();
        }
        else if (!player2Request && player1Request)
        {
            glitchiness = 0;
            player1.GetComponent<PlayerMovement>().UnFreeze();
            player1.GetComponent<PlayerMovement>().Move();
            player2.GetComponent<PlayerMovement>().Freeze();
        }
        else if (player1Request && player2Request)
        {
            glitchiness += .05f;
            player1.GetComponent<PlayerMovement>().Freeze();
            player2.GetComponent<PlayerMovement>().Freeze();
        }
        player1Request = false;
        player2Request = false;
    }

    internal void PlayerDie()
    {
        StartCoroutine("GlitchToDeath");
    }

    IEnumerator GlitchToDeath()
    {
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

    internal void FinishLevel(GameObject player)
    {
        if (player == player1)
        {
            player1Finish = true;
        }
        else
        {
            player2Finish = true;
        }
        if (player1Finish && player2Finish)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
