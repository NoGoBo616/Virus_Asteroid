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
    public bool die;
    public float speed;
    public Vector3 destino;
    public float[] times;
    public Image fill;
    public GameManager manager;
    public GameObject sprite;
    public GameObject pointsVFX;
    public Animator anim;
    public Player_ player;

    private void OnEnable()
    {
        manager = FindAnyObjectByType<GameManager>();
        player = FindAnyObjectByType<Player_>();
        lifeAmeba = 1f;
        timeAmeba =times[Random.Range(0,7)];
    }

    void Update()
    {
        Flip();
        fill.fillAmount = lifeAmeba;
        player = FindAnyObjectByType<Player_>();
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

        if (die == false)
        {
            if (lifeAmeba <= 0)
            {
                die = true;
                anim.SetTrigger("Die");
                rb.gravityScale = 1;
                Destroy(this.gameObject, 0.8f * Time.deltaTime);
            }
        }
    }
    
    private void FixedUpdate()
    {
       MoveAmeba();
    }

    void MoveAmeba()
    {
        Vector2 currentDirection = rb.linearVelocity.normalized;

        Vector2 directionToPlayer = ((Vector2)(player.transform.position - transform.position)).normalized;

        Vector2 newDirection = Vector2.Lerp(currentDirection, directionToPlayer, 3 * Time.fixedDeltaTime).normalized;

        rb.linearVelocity = newDirection * speed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("Police"))
        {
            lifeAmeba = lifeAmeba - 0.1f;
            anim.SetTrigger("Hurt");
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
            sprite.gameObject.transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        else
        {
            sprite.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        }
    }
}
