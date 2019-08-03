using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroScript : MonoBehaviour
{
    GlitchEffects glitch;
    // Start is called before the first frame update
    void Start()
    {
        glitch = GetComponent<GlitchEffects>();
        StartCoroutine("GlitchIn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GlitchIn()
    {
        glitch.enabled = true;
        for (float ft = 5f; ft >= 0; ft -= 0.1f)
        {
            glitch.colorIntensity = ft;
            glitch.flipIntensity = ft;
            yield return new WaitForSeconds(.001f);
        }
    }

    public void GlitchOut()
    {
        StartCoroutine("GlitchTransition");
    }

    IEnumerator GlitchTransition()
    {
        GetComponent<AudioSource>().Play();
        glitch.enabled = true;
        for (float ft = 0f; ft <= 5; ft += 0.1f)
        {
            glitch.colorIntensity = ft;
            glitch.flipIntensity = ft;
            yield return new WaitForSeconds(.001f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
