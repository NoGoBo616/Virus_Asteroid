using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmebaControl : MonoBehaviour
{
    public float lifeAmeba;
    public float timeAmeba;
    public Rigidbody2D rb;
    public bool flip;
    public float speed;
    public Vector3 destino;
    public float[] times;
    public Image fill;
    public GameManager manager;
    public GameObject sprite;
    public GameObject pointsVFX;

    private void OnEnable()
    {
        manager = FindAnyObjectByType<GameManager>();
        lifeAmeba = 1f;
        timeAmeba =times[Random.Range(0,7)];
        ChangeDestiny();
    }

    void Update()
    {
        Flip();
        fill.fillAmount = lifeAmeba;
        if (timeAmeba > 0)
        {
            timeAmeba -= Time.deltaTime;

        }
        if (timeAmeba <= 0)
        {
            timeAmeba = 0;
            Instantiate(pointsVFX, this.gameObject.transform.position, Quaternion.identity);
            manager.points = manager.points + 800;
            this.gameObject.SetActive(false);
        } 

        if (lifeAmeba <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void FixedUpdate()
    {
       MoveAmeba();
    }

    void MoveAmeba()
    {
        rb.linearVelocity = (Vector2)(destino - transform.position).normalized * speed;

        if (Vector2.Distance(transform.position, destino) <= 0.1f)
        {
            ChangeDestiny();
        }
    }

    void ChangeDestiny()
    {
        destino = new Vector3(UnityEngine.Random.Range(-10, 11), UnityEngine.Random.Range(-8, 9), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("Police"))
        {
            lifeAmeba = lifeAmeba - 0.1f;
        }
    }

    void Flip()
    {
        if (rb.linearVelocityX < 0)
        {
            flip = false;
        }
        if (rb.linearVelocityX > 0)
        {
            flip = true;
        }

        if (flip)
        {
            sprite.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            sprite.gameObject.transform.localScale = new Vector3(-1, 1, 1);

        }
    }
}
