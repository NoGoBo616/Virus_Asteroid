using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glob_Blanco : MonoBehaviour
{
    public float speed;
    public float turnSpeed; // Qu� tan r�pido gira hacia el jugador

    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Random.insideUnitCircle.normalized * speed;

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // Direcci�n actual del asteroide
        Vector2 currentDirection = rb.linearVelocity.normalized;

        // Direcci�n deseada hacia el jugador
        Vector2 directionToPlayer = ((Vector2)(player.position - transform.position)).normalized;

        // Interpolamos entre la direcci�n actual y la deseada
        Vector2 newDirection = Vector2.Lerp(currentDirection, directionToPlayer, turnSpeed * Time.fixedDeltaTime).normalized;

        rb.linearVelocity = newDirection * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(3);
                StartCoroutine(Agrandar());
            }
        }
    }

    private IEnumerator Agrandar()
    {
        gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        yield return null;
    }
}
