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
            
        }
    }

    void ChangeDestiny()
    {

    }
}
