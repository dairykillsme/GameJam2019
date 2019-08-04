using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneScript : MonoBehaviour
{

    public float movingTime = 1;
    public GameObject saveYou;
    public GameObject whoAreYou;
    public GameObject imYou;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Walking");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Walking()
    {
        yield return new WaitForSeconds(.1f);
        GameManager.instance.disabled = true;
        for (float i = 0; i < movingTime; i += .1f)
        {
            GameManager.instance.player1.GetComponent<PlayerMovement>().MoveLeft();
            yield return new WaitForSeconds(.01f);
        }
        StartCoroutine("SaveYou");
    }

    IEnumerator SaveYou()
    {
        yield return new WaitForSeconds(.5f);
        saveYou.SetActive(true);
        yield return new WaitForSeconds(2f);
        saveYou.SetActive(false);
        StartCoroutine("WhoAreYou");
    }

    IEnumerator WhoAreYou()
    {
        yield return new WaitForSeconds(.5f);
        whoAreYou.SetActive(true);
        yield return new WaitForSeconds(2f);
        whoAreYou.SetActive(false);
        StartCoroutine("ImYou");
    }

    IEnumerator ImYou()
    {
        yield return new WaitForSeconds(.5f);
        imYou.SetActive(true);
        yield return new WaitForSeconds(2f);
        imYou.SetActive(false);
    }

}
