using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Player_ : MonoBehaviour
{
    public float thrust = 1;
    public float rotationSpeed = 200;
    public float bulletSpeed = 100;

    private Rigidbody2D rb;
    private bool cooldownS;
    private bool cooldownI;
    private bool special;
    [SerializeField] public int shieldSfxIndex;
    [SerializeField] public int invisibleSfxIndex;
    

    [Header("Live")]
    public float live;

    [Header("Objects")]
    public GameObject bulletPrefab;
    public GameObject shield;
    public GameObject body;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cooldownS = true;
        cooldownI = true;
        special = true;
        live = 1;
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

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(7);
            }

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = transform.up * bulletSpeed;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (cooldownS && special)
            {
                StartCoroutine(Shield());
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cooldownI && special)
            {
                StartCoroutine(Invisible());
            }
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > 5)
        {
            rb.velocity = rb.velocity.normalized * 5;
            Debug.Log(rb.velocity.magnitude);
        }
    }

    //Corrutinas

    private IEnumerator Shield()
    {

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.sfxSource.pitch = Random.Range(0.9f, 1.1f);
            AudioManager.Instance.PlaySFX(5);
        }
        shield.SetActive(true);
        special = false;
        yield return new WaitForSeconds(2);
        shield.SetActive(false);
        special = true;
        StartCoroutine(CooldownShield());
        yield return null;
    }

    private IEnumerator Invisible()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.sfxSource.pitch = Random.Range(0.9f, 1.1f);
            AudioManager.Instance.PlaySFX(4);
        }
        body.gameObject.SetActive(false);
        special = false;
        yield return new WaitForSeconds(2);
        body.gameObject.SetActive(true);
        special = true;
        StartCoroutine(CooldownInvisible());
        yield return null;
    }

    private IEnumerator Daño()
    {
        
        body.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        body.gameObject.SetActive(true);
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
