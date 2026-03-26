using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto golpeado es un clon (hijo del asteroide)
        if (other.CompareTag("AsteroidClone"))
        {
            Destroy(other.gameObject);
        }
    }
}
