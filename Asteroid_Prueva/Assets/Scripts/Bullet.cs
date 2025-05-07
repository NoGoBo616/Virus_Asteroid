using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Live_System manager;

    void Start()
    {
        Destroy(gameObject, 2f); // Destruye después de 2 segundos
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto golpeado es un clon (hijo del asteroide)
        if (other.CompareTag("AsteroidClone"))
        {
            Destroy(other.gameObject); 
            Destroy(this.gameObject);
            manager.MorePoints();
        }
    }
}
