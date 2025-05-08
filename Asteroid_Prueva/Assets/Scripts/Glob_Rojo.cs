using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 5;
    public GameObject smallerAsteroidPrefab;
    public int size = 3;
    public GameManager manager;


    private Rigidbody2D rb;



    void Start()
    {
        MoveBlood();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > 10)
        {
            rb.velocity = rb.velocity.normalized * 10;
        }
    }

    void MoveBlood()
    {
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (size > 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject newAsteroid = Instantiate(smallerAsteroidPrefab, transform.position, Quaternion.identity);
                    newAsteroid.GetComponent<Asteroid>().size = size - 1;
                }
            }
        }
    }

    private void OnDisable()
    {
        manager.Puntuar();
    }
}
