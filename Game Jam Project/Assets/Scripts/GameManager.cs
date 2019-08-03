using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player1;
    public GameObject player2;

    bool player1Request = false;
    bool player2Request = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);
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
}
