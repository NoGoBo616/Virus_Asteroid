using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Player_ : MonoBehaviour
{
    public float thrust = 1.0f;
    public float rotationSpeed = 200.0f;
    public float bulletSpeed = 5f;

    private Rigidbody2D rb;
    private bool cooldownS;
    private bool cooldownI;

    [Header("Live")]
    public int live;

    [Header("Objects")]
    public GameObject bulletPrefab;
    public GameObject shield;
    public GameObject body;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cooldownS = true;
        cooldownI = true;
    }

    //Controles
    void Update()
    {
        float rotation = -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * thrust);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = transform.up * bulletSpeed;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (cooldownS)
            {
                StartCoroutine(Shield());
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cooldownI)
            {
                StartCoroutine(Invisible());
            }
        }
    }

    //Sistema de vida
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            live = live - 1;
        }
    }

    //Corrutinas

    private IEnumerator Shield()
    {
        shield.SetActive(true);
        yield return new WaitForSeconds(2);
        shield.SetActive(false);
        StartCoroutine(CooldownShield());
        yield return null;
    }

    private IEnumerator Invisible()
    {
        body.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        body.gameObject.SetActive(true);
        StartCoroutine(CooldownInvisible());
        yield return null;
    }

    private IEnumerator CooldownShield()
    {
        cooldownS = false;
        yield return new WaitForSeconds(2);
        cooldownS = true;
        yield return null;
    }

    private IEnumerator CooldownInvisible()
    {
        cooldownI = false;
        yield return new WaitForSeconds(2);
        cooldownI = true;
        yield return null;
    }
}
