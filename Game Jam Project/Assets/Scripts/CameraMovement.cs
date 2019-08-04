using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform player1,
        player2;

    public float zoomFactor = 1;
    float initialSize;

    // Start is called before the first frame update
    void Start()
    {
         player1 = GameManager.instance.player1.GetComponent<Transform>();
         player2 = GameManager.instance.player2.GetComponent<Transform>();
         initialSize = GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDistance = player1.position - player2.position;
        Vector3 cameraPosition = (player1.position + player2.position) / 2;
        cameraPosition.z = -10;
        transform.position = cameraPosition;
        if (playerDistance.magnitude > initialSize)
        {
            GetComponent<Camera>().orthographicSize = zoomFactor * playerDistance.magnitude;
        }
    }
}
