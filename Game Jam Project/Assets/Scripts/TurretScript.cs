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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fire");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Fire()
    {
        GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        newBullet.GetComponent<BulletScript>().speed = bulletSpeed;
        newBullet.GetComponent<BulletScript>().direction = firingVector;
        yield return new WaitForSeconds(firingRate);
        StartCoroutine("Fire");
    }
}
