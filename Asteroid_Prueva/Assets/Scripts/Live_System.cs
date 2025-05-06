using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live_System : MonoBehaviour
{
    public float vida;

    private void Start()
    {
        vida = 1;
    }

    private void Update()
    {
        if (vida <= 0)
        {
            vida = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            vida = vida - 0.05f;
            Debug.Log(vida);
        }
    }
}
