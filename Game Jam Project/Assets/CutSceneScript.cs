using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneScript : MonoBehaviour
{

    public float movingTime = 1;
    public GameObject saveYou;
    public GameObject whoAreYou;
    public GameObject imYou;
    public GameObject fromFuture;
    public Transform player1Start;
    public Transform player2Start;
    public GameObject whatsHappening;
    public GameObject timeExpects;
    public GameObject quantum;
    public GameObject onlyOne;
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
        StartCoroutine("FromFuture");
    }

    IEnumerator FromFuture()
    {
        yield return new WaitForSeconds(.5f);
        fromFuture.SetActive(true);
        yield return new WaitForSeconds(1f);
        GameManager.instance.Glitch();
        GameManager.instance.player1.GetComponent<Transform>().position = player1Start.position;
        yield return new WaitForSeconds(1f);
        fromFuture.SetActive(false);
        GameManager.instance.player2.GetComponent<Transform>().position = player2Start.position;
        StartCoroutine("WhatsHappening");
    }

    IEnumerator WhatsHappening()
    {
        yield return new WaitForSeconds(.5f);
        whatsHappening.SetActive(true);
        yield return new WaitForSeconds(2f);
        whatsHappening.SetActive(false);
        StartCoroutine("TimeExpects");
    }

    IEnumerator TimeExpects()
    {
        yield return new WaitForSeconds(.5f);
        timeExpects.SetActive(true);
        yield return new WaitForSeconds(2f);
        timeExpects.SetActive(false);
        StartCoroutine("Quantum");
    }

    IEnumerator Quantum()
    {
        yield return new WaitForSeconds(.5f);
        quantum.SetActive(true);
        yield return new WaitForSeconds(2f);
        quantum.SetActive(false);
        StartCoroutine("OnlyOne");
    }

    IEnumerator OnlyOne()
    {
        yield return new WaitForSeconds(.5f);
        onlyOne.SetActive(true);
        yield return new WaitForSeconds(2f);
        onlyOne.SetActive(false);
        StartCoroutine("End");
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(.5f);
        GameManager.instance.player1.GetComponent<PlayerMovement>().UnFreeze();
        GameManager.instance.player2.GetComponent<PlayerMovement>().UnFreeze();
        GameManager.instance.disabled = false;
    }

}
