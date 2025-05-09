using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glob_Blanco : MonoBehaviour
{
    public float speed = 2.5f;
    public float turnSpeed = 1.5f; // Qué tan rápido gira hacia el jugador

    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Random.insideUnitCircle.normalized * speed;

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // Dirección actual del asteroide
        Vector2 currentDirection = rb.velocity.normalized;

        // Dirección deseada hacia el jugador
        Vector2 directionToPlayer = ((Vector2)(player.position - transform.position)).normalized;

        // Interpolamos entre la dirección actual y la deseada
        Vector2 newDirection = Vector2.Lerp(currentDirection, directionToPlayer, turnSpeed * Time.fixedDeltaTime).normalized;

        rb.velocity = newDirection * speed;

        // (Opcional) Rotar el sprite hacia la dirección de movimiento
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90f; // Ajusta según tu sprite
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(3);
            }
        }
    }
}
