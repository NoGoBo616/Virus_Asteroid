using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmebaControl : MonoBehaviour
{
    public float lifeAmeba;
    public float timeAmeba;
    public Rigidbody2D rb;
    public bool flying;
    [SerializeField] float speed;
    public Vector3 destino;
    public float[] times;

    private void OnEnable()
    {
        lifeAmeba = 1f;
        timeAmeba =times[Random.Range(0,7)];
        ChangeDestiny();
    }

    void Update()
    {
        if (timeAmeba > 0)
        {
            timeAmeba -= Time.deltaTime;

        }
        if (timeAmeba <= 0)
        {
            timeAmeba = 0;
            this.gameObject.SetActive(false);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            

            lifeAmeba = lifeAmeba - 0.05f;
        }
    }
}
