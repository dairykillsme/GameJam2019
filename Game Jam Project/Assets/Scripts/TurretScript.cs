using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float firingRate = 1f;
    public float bulletSpeed = 7;
    public Vector2 firingVector = Vector2.left;
    public Animator turretAnimator;
    private float magicNumber = 61f / 60f;
    private AudioSource turretAudio;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fire");
        turretAnimator = GetComponent<Animator>();
        turretAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Fire()
    {
        turretAnimator.speed = magicNumber / firingRate;
        turretAnimator.SetTrigger("firing");
        yield return new WaitForSeconds(2 * firingRate / 3);
        GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        newBullet.GetComponent<BulletScript>().speed = bulletSpeed;
        newBullet.GetComponent<BulletScript>().direction = firingVector;
        turretAudio.Play();
        yield return new WaitForSeconds(1 * firingRate / 3);
        StartCoroutine("Fire");
    }
}
